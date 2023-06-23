using GoodTrading.Model.Entities;
using GoodTrading.Utilities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GoodTrading.ViewModel.HistoryTradeViewModel
{
    internal class HistoryTradeViewModel:BindableBase
    {
        //private readonly GoodsTradingContext _context;

        private List<TrandingHistory> sourceHistoryItem;

        public List<TrandingHistory> SourceHistoryItem
        {
            get { return sourceHistoryItem; }
            set {
                SetProperty(ref sourceHistoryItem, value);
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


        //ICommand cancelBtnLicked { get; set; }
        //public HistoryTradeViewModel()
        //{
        //    cancelBtnLicked = new AsyncRelayCommand(cancel, ex => Message = ex.Message);
        //}

        //private void cancel()
        //{
            
        //    try
        //    {
        //        currentWindow.Close();
        //    }
        //    catch
        //    {
        //        Message = "Error in closse window";
        //    }
            
        //}
    }
}
