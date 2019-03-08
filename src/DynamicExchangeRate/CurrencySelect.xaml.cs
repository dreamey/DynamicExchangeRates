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
using DynamicExchangeRateLib;
using MahApps.Metro.Controls;

namespace DynamicExchangeRate
{
    /// <summary>
    /// Interaction logic for CurrencySelect.xaml
    /// </summary>
    public partial class CurrencySelect : MetroWindow
    {
        public List<ExchangeRate.Currency> SelectedCurrencies = new List<ExchangeRate.Currency>(); 

        public CurrencySelect()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var currency in ExchangeRate.GetCurrencies())
            {
                _baseCurrencyCombobox.Items.Add(currency.ToString());
            }
        }

        private void _baseCurrencyCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _subCurrencyCombobox.Visibility = Visibility.Visible;
            _subCurrencyCombobox.Items.Clear();
            foreach (var currency in ExchangeRate.GetCurrencies())
            {
                if(currency.ToString() != _baseCurrencyCombobox.SelectedItem.ToString())
                {
                    _subCurrencyCombobox.Items.Add(currency);
                }
            }
            _subCurrencyCombobox1.Items.Clear();
            _confirmButton.Visibility = Visibility.Hidden;
        }

        private void _subCurrencyCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_subCurrencyCombobox.Items.Count == 0) { return; }
            _subCurrencyCombobox1.Visibility = Visibility.Visible;
            _subCurrencyCombobox1.Items.Clear();
            foreach (var currency in ExchangeRate.GetCurrencies())
            {
                if (currency.ToString() != _subCurrencyCombobox.SelectedItem.ToString() && currency.ToString() != _baseCurrencyCombobox.SelectedItem.ToString())
                {
                    _subCurrencyCombobox1.Items.Add(currency);
                    //If only 1 sub currency can be chosen, then auto fill it
                    if (_subCurrencyCombobox1.Items.Count == 1) { _subCurrencyCombobox1.SelectedIndex = 0; _confirmButton.Visibility = Visibility.Visible; }
                }
            };
         }

        private void _confirmButton_Click(object sender, RoutedEventArgs e)
        {
            ExchangeRate.Currency BaseCurrency = ExchangeRate.StrToCurrency(_baseCurrencyCombobox.SelectedItem.ToString());
            var CurrencyList = new List<ExchangeRate.Currency>
            {
                ExchangeRate.StrToCurrency(_subCurrencyCombobox.SelectedItem.ToString()),
                ExchangeRate.StrToCurrency(_subCurrencyCombobox1.SelectedItem.ToString())
            };

            //Creates a new Page without distorting window resolution or creating a new window
            App.ElementHandles.ExchangeRateInputHWND = new ExchangeRateInput(BaseCurrency, CurrencyList);
            CurrencySelectMainGrid.Children.Clear();
            CurrencySelectMainGrid.Children.Add(App.ElementHandles.ExchangeRateInputHWND);
        }
    }
}
