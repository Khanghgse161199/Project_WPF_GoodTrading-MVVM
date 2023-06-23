﻿using GoodTrading.ViewModel.CreateGoodViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GoodTrading.Views
{
    /// <summary>
    /// Interaction logic for CreateProduct.xaml
    /// </summary>
    public partial class CreateProduct : Window
    {
        public CreateProduct()
        {
            CreateGoodViewModel vm = new CreateGoodViewModel();
            vm.CurrentWindow = this;
            DataContext = vm;
            InitializeComponent();
        }
    }
}
