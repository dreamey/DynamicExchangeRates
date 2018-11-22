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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DynamicExchangeRateLib;

namespace DynamicExchangeRate
{
    /// <summary>
    /// Interaction logic for ExchangeRateInput.xaml
    /// </summary>
    public partial class ExchangeRateInput : UserControl
    {
        private ExchangeRate.Currency BaseCurrency;
        private List<ExchangeRate.Currency> SubCurrencyList;

        public ExchangeRateInput(ExchangeRate.Currency BaseCurrency, List<ExchangeRate.Currency> SubCurrencyList)
        {
            InitializeComponent();
            this.BaseCurrency = BaseCurrency;
            this.SubCurrencyList = SubCurrencyList;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var _subCurrency in SubCurrencyList)
            {

                var currGrid = new Grid();

                RowDefinition currRow = new RowDefinition();
                currGrid.RowDefinitions.Add(newRow);


                //Populate parent
                currGrid.Children.Add(currDescription);


                ExchangeRateInputMainStackPanel.Children.Add(currGrid);
            }
        }

        private void InitGrid()
        {
            var currGrid = new Grid();

            for (int i = 0; i < SubCurrencyList.Count; i++)
            {
                RowDefinition currRow = new RowDefinition();
                currGrid.RowDefinitions.Add(currRow);

                string BaseSubText = $"{BaseCurrency.ToString()}/{SubCurrencyList[i]}";
                var currDescription = new TextBlock
                {
                    Text = BaseSubText,
                    Margin = new Thickness(20)
                };
            }
        }


        private Dictionary<string, TextBox> StrToElement = new Dictionary<string, TextBox>();
    }
}
