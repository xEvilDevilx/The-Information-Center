using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Xml;

using IC.CurrencyRatesTool.Interfaces;

namespace IC.CurrencyRatesTool.Plugins.Euro
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
            try
            {
                var currencyRates = new Dictionary<string, decimal>();
                var cultures = new CultureInfo("en-US");
                using (var webClient = new WebClient())
                {
                    var xml = webClient.DownloadString("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    foreach (XmlElement child in xmlDoc.DocumentElement.ChildNodes[2].ChildNodes[0])
                    {
                        var currency = child.Attributes[0].InnerText;
                        var rate = child.Attributes[1].InnerText;
                        var decimalRate = decimal.Parse(rate, cultures);
                        currencyRates.Add(currency, decimalRate);
                    }
                    currencyRates.Add("EUR", 1.00m);
                }

                return currencyRates;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}