using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            Currency[] values = (Currency[])Enum.GetValues(typeof(Currency));
            return values;
        }

        public static Currency StrToCurrency(string Str)
        {
            switch (Str)
            {
                case "GBP":
                    return Currency.GBP;
                case "EUR":
                    return Currency.EUR;
                case "USD":
                    return Currency.USD;
                default:
                    throw new InvalidCastException();
            }


        }

    }
}
