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
using System.Text.RegularExpressions;

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
            _FirstCurrencyLabel.Content = SubCurrencyList[0].ToString();
            _SecondCurrencyLabel.Content = SubCurrencyList[1].ToString();
            _BaseCurrencyLabel.Content = "BASE: " + BaseCurrency;
        }

        private void CheckLength(object sender, TextChangedEventArgs e)
        {
            var CurrentTextbox = ((TextBox)sender);
            /*if(!IntCheck(CurrentTextbox.Text))
            {
                var text = CurrentTextbox.Text;
                text = text.Remove(CurrentTextbox.Text.Length-1);
                CurrentTextbox.Text = text;
                CurrentTextbox.SelectionStart = CurrentTextbox.Text.Length;
            }
            */
            if (CurrentTextbox.Text.Length > 7)
            {
                CurrentTextbox.Text = CurrentTextbox.Text.Remove(CurrentTextbox.Text.Length - 1);
                CurrentTextbox.SelectionStart = CurrentTextbox.Text.Length;
            }

            if (!(Regex.IsMatch(CurrentTextbox.Text, "^(([0-9]+)|([.,]))+$")))
            {

                if (CurrentTextbox.Text.Length - 1 >= 0)
                {
                    CurrentTextbox.Text = CurrentTextbox.Text.Remove(CurrentTextbox.Text.Length - 1,1);
                    CurrentTextbox.SelectionStart = CurrentTextbox.Text.Length;
                }
            }

        }
    }
}
