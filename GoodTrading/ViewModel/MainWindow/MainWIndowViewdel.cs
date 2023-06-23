using GoodTrading.Model.Entities;
using GoodTrading.Model.Service.AuthService;
using GoodTrading.Model.Service.GoodsService;
using GoodTrading.Model.Service.TokenService;
using GoodTrading.Model.Service.UserService;
using GoodTrading.Utilities;
using GoodTrading.ViewModel.WorkSpaceWindow;
using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace GoodTrading.ViewModel.MainWindow
{
    class MainWIndowViewdel: BindableBase
    {
		private readonly UserService _userService;
		private readonly AuthService _authService;
		private readonly TokenService _tokenService;
		private readonly GoodsService _good;

		private bool isLogin;

		public bool IsLogin
		{
			get { return isLogin; }
			set { 
			SetProperty(ref isLogin, value);
			}
		}

		private Window currentWindow;

		public Window CurrentWindow
        {
			get { return currentWindow; }
			set { 
			SetProperty( ref currentWindow, value);
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


		private string userName;

		public string UserName
		{
			get { return userName; }
			set { 
			SetProperty(ref userName, value);
			}
		}

		private string password;

		public string Password
		{
			get { return password; }
			set { 
			SetProperty(ref password, value);
			}
		}

		public ICommand LoginButton { get; set; }
		public ICommand RegisterButtonClicked { get; set; }	
		public MainWIndowViewdel()
		{
			RegisterButtonClicked = new AsyncRelayCommand(Register, ex => Message = ex.Message);
            LoginButton = new AsyncRelayCommand(Login, ex => Message = ex.Message);
            _userService = new UserService();
			_authService = new AuthService();
            _tokenService = new TokenService();
			_good = new GoodsService();
        }

		public async Task Register()
	{
			if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password)){
				bool isCreated = await _userService.CreateUser(new User()
				{
				
					PassWord = Password,
					UserName = UserName,
				});
                if (isCreated)
                {
                    Message = "Register success";
                }
                else
                {
                    Message = "Register Error";
                }
			}
			else
			{
                Message = "Please input!";
            }
			
        }

		public bool canRegister()
		{
			if(UserName == string.Empty)
			{
				return false;
			}else return true;
		}
        public async Task Login()
        {
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
				bool isLogin = await _authService.Login(UserName, Password);                    
                if (isLogin)
                {
				IsLogin = true;
				currentWindow.Hide();
                    Views.WorkSpaceWindow workSpaceWindow = new Views.WorkSpaceWindow();
					var goods = await _good.getExcepcurrentUserAsync();
					ObservableCollection<Product> list = new ObservableCollection<Product>();
					foreach (var item in goods)
					{
						list.Add(item);
					}
					WorkSpaceWindowViewModel vm = new WorkSpaceWindowViewModel();
					vm.Username = UserName;
                    vm.AllGoods = list;
					vm.CurrentWindow = workSpaceWindow;
                    workSpaceWindow.DataContext = vm;
					workSpaceWindow.Show();
				}
                else
                {
                    Message = "UserName and Password is In-Correct";
                }
            }
            else
            {
                Message = "Please input!";
            }
        }
        public async Task<bool> CheckToken()
        {
			var result = await _tokenService.checkToken();
			if (result != null)
			{
				string path = Directory.GetCurrentDirectory();
				string fileName = "user.cache";
				string fullpath = Path.Combine(path, fileName);
				string ramData = JsonConvert.SerializeObject(result);
				return true;
			}else
			{
				return false;
			}
        }

    }
}
