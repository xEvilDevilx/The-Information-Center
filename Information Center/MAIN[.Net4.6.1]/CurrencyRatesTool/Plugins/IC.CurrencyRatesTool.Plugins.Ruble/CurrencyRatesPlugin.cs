using System;
using System.Collections.Generic;
using System.Xml;

using IC.CurrencyRatesTool.Interfaces;

namespace IC.CurrencyRatesTool.Plugins.Ruble
{
    /// <summary>
    /// Implements Currency Rates logic
    /// 
    /// 2017/04/17 - Created, VTyagunov
    /// </summary>
    public class CurrencyRatesPlugin : ICurrencyRatesPlugin
    {
        /// <summary>
        /// Use for Get Currency Rates from web
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, decimal> Get()
        {
            var currencyRates = new Dictionary<string, decimal>();
            string currencyCode = "";
            decimal currencyRate = 0.0m;

            try
            {
                using (var reader = new XmlTextReader("http://www.cbr.ru/scripts/XML_daily.asp"))
                {
                    while (reader.ReadToFollowing("Valute"))
                    {
                        reader.ReadToFollowing("CharCode");
                        reader.Read();
                        currencyCode = reader.Value;

                        reader.ReadToFollowing("Value");
                        reader.Read();
                        var value = reader.Value;
                        if (value.Contains(","))
                            value = value.Replace(",", ".");
                        if (decimal.TryParse(value, out currencyRate))
                            currencyRates.Add(currencyCode, currencyRate);
                    }
                    currencyRates.Add("RUB", 1.00m);
                }
                return currencyRates;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}