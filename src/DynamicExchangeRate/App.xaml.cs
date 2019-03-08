using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DynamicExchangeRate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public struct ElementHandles
        {
            public static MainWindow MainWindowHWND;
            public static CurrencySelect CurrencySelectHWND;
            public static ExchangeRateInput ExchangeRateInputHWND;
            public static MainMenu MainMenuHWND;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ElementHandles.CurrencySelectHWND = new CurrencySelect();
            ElementHandles.CurrencySelectHWND.ShowDialog();

        }
    }
}
