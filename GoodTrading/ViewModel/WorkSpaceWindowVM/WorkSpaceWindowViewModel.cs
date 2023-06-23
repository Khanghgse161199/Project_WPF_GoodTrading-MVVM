using GoodTrading.Model.Entities;
using GoodTrading.Model.Service.GoodsService;
using GoodTrading.Model.Service.HistoryService;
using GoodTrading.Model.Service.TokenService;
using GoodTrading.Utilities;
using GoodTrading.Views;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GoodTrading.ViewModel.WorkSpaceWindow
{
    internal class WorkSpaceWindowViewModel:BindableBase
    {
        private readonly TokenService _token;
        private readonly GoodsService _good;
        private readonly Hisrotyservice _history;
        private ObservableCollection<Product> allGoods;

        private Product goodChoice;

        public Product GoodChoice
        {
            get { return goodChoice; }
            set { 
            SetProperty(ref goodChoice, value);
            }
        }


        private string username;

        public string Username
        {
            get { return username; }
            set { 
            SetProperty(ref username, value);
            }
        }


        public ObservableCollection<Product> AllGoods
        {
            get { return allGoods; }
            set {
                SetProperty(ref allGoods, value);
            }
        }

        private string searchValue;

        public string SearchValue
        {
            get { return searchValue; }
            set {
                SetProperty(ref searchValue, value);
            }
        }

        public ICommand LogoutButtonClicked { get; set; }
        public ICommand UpLoadButtonClicked { get; set; }

        public ICommand UserGoodsList { get; set; }
        public ICommand refreshBtnClick { get; set; }

        public ICommand SearchButtonClicked { get; set; }

        public ICommand TradeButtonCliked { get; set; }

        public ICommand UserHistoryTrade { get; set; }

        private Window currentWindow;

        public Window CurrentWindow
        {
            get { return currentWindow; }
            set { 
            SetProperty(ref currentWindow, value);
            }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set
            {
                SetProperty(ref message, value);
            }
        }

        public WorkSpaceWindowViewModel()
        {
            _token = new TokenService();
            _good = new GoodsService();
            _history = new Hisrotyservice();
            LogoutButtonClicked = new AsyncRelayCommand(LogOut, ex => Message = ex.Message);
            UpLoadButtonClicked = new AsyncRelayCommand(UpLoadGood, ex => Message = ex.Message);
            UserGoodsList = new AsyncRelayCommand(getUserGoods, ex => Message = ex.Message);
            refreshBtnClick = new AsyncRelayCommand(GetGoods, ex => Message = ex.Message);
            SearchButtonClicked = new AsyncRelayCommand(Search, ex => Message = ex.Message);
            TradeButtonCliked = new AsyncRelayCommand(Trade, ex => Message = ex.Message);
            UserHistoryTrade = new AsyncRelayCommand(HistoryTrade, ex => Message = ex.Message);
        }

        public async Task HistoryTrade()
        {
            var checkToken = await _token.checkToken();
            if(checkToken != null)
            {
                HistoryTradeWindow hw = new HistoryTradeWindow();
                HistoryTradeViewModel.HistoryTradeViewModel vm = new ViewModel.HistoryTradeViewModel.HistoryTradeViewModel();
                hw.DataContext = vm;
                vm.SourceHistoryItem = await _history.getHistoryLists(checkToken.UserId);


                hw.ShowDialog();
            }
            else
            {
                Message = "Sorry You not have any trade now !"; 
            }
        }

        public async Task getNameUser()
        {
            var checkToken = await _token.checkToken();
            if (checkToken != null)
            {
                Username = checkToken.UserName;
            }
        }

        public async Task Trade()
        {
            if (GoodChoice != null)
            {
                TradeWindow tradeWindow = new TradeWindow();
                TradingViewModel.TradingViewModel vm = new TradingViewModel.TradingViewModel();
                vm.UserGoods = await _good.GetUserAndPrice(GoodChoice.Price);
                vm.UserGoodChoice = GoodChoice;
                vm.CurrentWindow = tradeWindow;
                tradeWindow.DataContext = vm;
                tradeWindow.ShowDialog();
            }
        }

        public async Task Search()
        {
            if (!string.IsNullOrEmpty(SearchValue))
            {
                var goods = await _good.FindByName(SearchValue);
                if(goods != null ) {
                    AllGoods = new ObservableCollection<Product>();
                    foreach (var item in goods)
                    {
                        AllGoods.Add(item);
                    }
                }
                else
                {
                    Message = "Can not find any product!";
                }
            }
            else
            {
                Message = "Can not find any product!";
            }
        }
        public async Task GetGoods()
        {
            var checkToken = await _token.checkToken();
            if(checkToken != null )
            {
                Username = checkToken.UserName;
                var goods = await _good.getExcepcurrentUserAsync();
                if (goods != null)
                {
                    var list = new ObservableCollection<Product>();
                    foreach (var item in goods)
                    {
                        list.Add(item);
                    }
                    AllGoods = list;
                }
                else
                {
                    Message = "Not have good to trading";
                }
            }
           
        }

        public async Task getUserGoods()
        {
            var goods = await _good.GetByCurrentUserAsync();
            if(goods != null) {
                UserGoods userGoods = new UserGoods();
                UserGoodViewModel.UserGoodViewModel vm = new UserGoodViewModel.UserGoodViewModel();
                vm.ListOfGoods = new System.Collections.ObjectModel.ObservableCollection<Product>();
                foreach (var item in goods)
                {
                    vm.ListOfGoods.Add(item);
                }
                userGoods.DataContext = vm;
                userGoods.ShowDialog();
            }
            else
            {
                Message = "Not found ant goods";
            }
        }
        public async Task UpLoadGood()
        {
            var checkToken = await _token.checkToken();
            if(checkToken != null)
            {
                CreateProduct createProduct = new CreateProduct();
                createProduct.ShowDialog();
            }
            else
            {
                CurrentWindow.Hide();
                GoodTrading.MainWindow main = new GoodTrading.MainWindow();
                main.Show();
            }
        }
        public async Task LogOut()
        {
            bool result = await _token.DeacTive();
            if (result)
            {
                CurrentWindow.Hide();
                GoodTrading.MainWindow main = new GoodTrading.MainWindow();
                main.Show();
            }
            else
            {
                Message = "Error while logout";
            }
        }    
    }
}
