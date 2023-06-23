using GoodTrading.Model.Service.GoodsService;
using GoodTrading.Model.Service.TokenService;
using GoodTrading.Utilities;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GoodTrading.ViewModel.CreateGoodViewModel
{
    internal class CreateGoodViewModel: BindableBase
    {
		private readonly GoodsService _goodsService;
        private readonly TokenService _tokenService;

        private Window currentWindow;

		public Window CurrentWindow
        {
			get { return currentWindow; }
			set { 
			SetProperty(ref currentWindow, value);
			}
		}


		private string productName;

		public string ProductName
		{
			get { return productName; }
			set {
			SetProperty(ref productName, value);	
			}
		}

		private string productPrice;

		public string ProductPrice
        {
			get { return productPrice; }
			set {
				SetProperty(ref productPrice, value);
			}
		}

		private string productDescription;

		public string ProductDescription
        {
			get { return productDescription; }
			set {
				SetProperty(ref productDescription, value);
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


		public ICommand CreateButtonClicked { get; set; }
		public ICommand CancelButtonClicked { get; set; }

        public CreateGoodViewModel()
		{
			_goodsService = new GoodsService();
			_tokenService = new TokenService();
            CreateButtonClicked = new AsyncRelayCommand(createProduct, ex => Message = ex.Message);
            CancelButtonClicked = new AsyncRelayCommand(Cancel, ex => Message = ex.Message);
        }

		private async Task Cancel()
		{
            CurrentWindow.Hide();
        }
		private async Task<bool> createProduct()
		{
			var checkToken = await _tokenService.checkToken();
			if (checkToken != null)
			{
                if (ProductName != null && ProductPrice != null && ProductDescription != null)
                {
                    var result = await _goodsService.CreateGoods(new TempModel.GoodModel.GoodCreateModel()
                    {
                        Description = ProductDescription,
                        Name = ProductName,
                        Price = double.Parse(ProductPrice),
                    });

                    if (result)
                    {
                        Message = "Create Product successful";
                        CurrentWindow.Hide();
						return true;
                    }
                    else
                    {
                        Message = "Error while creating new product";
                        return false;
                    }
                }
                else
                {
                    message = "Infor input not null!";
                    return false;
                }
			}
			else
			{
				return false;
			}
        }




    }
}
