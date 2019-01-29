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

        private void FirstCurrencyLable_Loaded(object sender, RoutedEventArgs e)
        {
            //this.Content = SubCurrencyList[0].ToString();
        }

        private void SecondCurrencyLable_Loaded(object sender, RoutedEventArgs e)
        {
            //this.Content = SubCurrencyList[1].ToString();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
            /*var currGrid = new Grid();//When the ExchangeRateInput is open, it automatically creates a new grid.

            
            For loop adjusts the amount of rows need to be added
            3 columns and 1 row remain contant when loaded
            row n, column 1 will be the listed subcurrency
            row n, column 2 will be the buy rate
            row n, column 3 will be the sell rate
            
            for (int i = 0; i < SubCurrencyList.Count; i++)
            {
                RowDefinition currRow = new RowDefinition();
                currGrid.RowDefinitions.Add(currRow);

                string BaseSubText = $"{BaseCurrency.ToString()}/{SubCurrencyList[i]}";
                var currDescription = new TextBlock
                {
                    Text = BaseSubText,
                    Margin = new Thickness(1),
                    Foreground = new SolidColorBrush(Colors.Black)
                };

                Grid.SetColumn(currDescription, 0);
                Grid.SetRow(currDescription, 0);

                //currRow.SetValue(dp, currDescription);
            }
            ExchangeRateInputMainGrid.Children.Add(currGrid);
            */
            
        }
        /*
        private void InitGrid(object sender, RoutedEventArgs e)
        {
            var currGrid = new Grid();//When the ExchangeRateInput is open, it automatically creates a new grid.
            
            
            For loop adjusts the amount of rows need to be added
            3 columns and 1 row remain contant when loaded
            row n, column 1 will be the listed subcurrency
            row n, column 2 will be the buy rate
            row n, column 3 will be the sell rate
            
            for (int i = 0; i < SubCurrencyList.Count; i++)
            {
                RowDefinition currRow = new RowDefinition();
                currGrid.RowDefinitions.Add(currRow);

                string BaseSubText = $"{BaseCurrency.ToString()}/{SubCurrencyList[i]}";
                var currDescription = new TextBlock
                {
                    Text = BaseSubText,
                    Margin = new Thickness(1),
                    Foreground = new SolidColorBrush(Colors.Black)
                };

                Grid.SetColumn(currDescription, 0);
                Grid.SetRow(currDescription, 0);

                //currRow.SetValue(dp, currDescription);
            }
        }*/

        private Dictionary<string, TextBox> StrToElement = new Dictionary<string, TextBox>();
    }
}
