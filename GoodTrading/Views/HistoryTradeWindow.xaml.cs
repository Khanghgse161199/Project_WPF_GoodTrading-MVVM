using GoodTrading.ViewModel.HistoryTradeViewModel;
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
    /// Interaction logic for HistoryTradeWindow.xaml
    /// </summary>
    public partial class HistoryTradeWindow : Window
    {
        public HistoryTradeWindow()
        {
            HistoryTradeViewModel vm = new HistoryTradeViewModel();
            DataContext = vm;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
