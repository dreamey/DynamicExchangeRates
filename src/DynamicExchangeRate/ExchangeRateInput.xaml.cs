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
            _FirstCurrencyLabel.Content = SubCurrencyList[0].ToString();
            _SecondCurrencyLabel.Content = SubCurrencyList[1].ToString();
            _BaseCurrencyLabel.Content = "BASE: " + BaseCurrency;
        }

        private void CheckLength(object sender, TextChangedEventArgs e)
        {
            var CurrentTextbox = ((TextBox)sender);
            var text = CurrentTextbox.Text;

            if (CurrentTextbox.Text.Length > 7)
            {
                CurrentTextbox.Text = CurrentTextbox.Text.Remove(CurrentTextbox.Text.Length - 1);
                CurrentTextbox.SelectionStart = CurrentTextbox.Text.Length;
            }

            CurrentTextbox.Text = IntCheck(text);
        }

        private static string IntCheck(string Str)
        {
            var length = Str.Length;

            for (int i = 0; i < length - 1; i++)
            {
                var ISInteger = char.IsDigit(Str[i]);
                if (!ISInteger)
                {
                    MessageBox.Show("ur uncle is in pen");
                    Str.Remove(i, 1);
                }
            }

            return Str;

        }
    }
}
