using GoodTrading.Model.Entities;
using GoodTrading.Model.Service.GoodsService;
using GoodTrading.Model.Service.TradingServices;
using GoodTrading.Utilities;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GoodTrading.ViewModel.TradingViewModel
{
    internal class TradingViewModel: BindableBase
    {
        private readonly TradingService _tradingService;

        private readonly GoodsService _good;

        private Product doodChoice;

        public Product GoodChoice
        {
            get { return doodChoice; }
            set { 
            SetProperty(ref doodChoice, value);
            }
        }

        private Product toGood;

        public Product ToGood
        {
            get { return toGood; }
            set { 
            SetProperty(ref toGood, value);
            }
        }


        private string message;

        public string Message
        {
            get { return message; }
            set { 
            SetProperty(ref message, value);    
            }
        }

        private Product userGoodChoice;

        public Product UserGoodChoice
        {
            get { return userGoodChoice; }
            set {
                SetProperty(ref userGoodChoice, value);
            }
        }


        private List<Product> userGoods;

        public List<Product>UserGoods
        {
            get { return userGoods; }
            set { 
            SetProperty(ref userGoods, value);
            }
        }

        private Window currentWindow;

        public Window CurrentWindow
        {
            get { return currentWindow; }
            set {
                SetProperty(ref currentWindow, value);
            }
        }

        public ICommand ConfrimBtnClicked { get; set; }
        public TradingViewModel()
        {
            _tradingService = new TradingService();
            ConfrimBtnClicked = new AsyncRelayCommand(Confirm, ex => Message = ex.Message);
        }
        
        public async Task Confirm()
        {
            if(UserGoodChoice != null && ToGood != null)
            {
                var result = await _tradingService.Trade(UserGoodChoice.Id, ToGood.Id);
                if (result)
                {
                    currentWindow.Close();
                }
            }
        }



    }
}
