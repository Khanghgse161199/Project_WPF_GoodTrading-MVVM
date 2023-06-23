
using GoodTrading.Model.Service.TokenService;
using GoodTrading.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GoodTrading
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Task.Run(async () =>
            {
               Application_StartupAsync();
            }).GetAwaiter().GetResult();
        }
        private async Task Application_StartupAsync()
        {
            TokenService tokenService = new TokenService();
            var checkedToken = await tokenService.checkToken();
            if (checkedToken != null)
            {
                try
                {
                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        WorkSpaceWindow nextWindown = new WorkSpaceWindow();
                        nextWindown.Show();
                    });
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                });
            }
        }
    }
}
