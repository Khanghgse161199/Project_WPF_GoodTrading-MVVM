using GoodTrading.Model.Entities;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodTrading.ViewModel.UserGoodViewModel
{
    internal class UserGoodViewModel: BindableBase
    {
        private ObservableCollection<Product> listOfGoods;

        public ObservableCollection<Product> ListOfGoods
        {
            get { return listOfGoods; }
            set 
            {
                SetProperty(ref listOfGoods, value);
            }
        }
    }
}
