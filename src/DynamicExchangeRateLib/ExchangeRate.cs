using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicExchangeRateLib
{
    public class ExchangeRate
    {
        public enum Currency
        {
            EUR,
            GBP,
            USD
        }

        public static Currency[] GetCurrencies()
        {
            ExchangeRate.Currency[] values = (ExchangeRate.Currency[])Enum.GetValues(typeof(ExchangeRate.Currency));
            return values;
        }

        public static Dictionary<string, Currency> StrToCurrency = new Dictionary<string, Currency>
        {
            { "EUR", Currency.EUR },
            { "GBP", Currency.GBP },
            { "EUR", Currency.USD }
        };

    }
}
