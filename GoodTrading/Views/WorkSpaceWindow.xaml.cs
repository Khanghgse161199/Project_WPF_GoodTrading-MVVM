using GoodTrading.ViewModel.WorkSpaceWindow;
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
    /// Interaction logic for WorkSpaceWindow.xaml
    /// </summary>
    public partial class WorkSpaceWindow : Window
    {
        public WorkSpaceWindow()
        {
            WorkSpaceWindowViewModel vm = new WorkSpaceWindowViewModel();
            vm.CurrentWindow = this;
            DataContext = vm;
            InitializeComponent();      
        }
    }
}
