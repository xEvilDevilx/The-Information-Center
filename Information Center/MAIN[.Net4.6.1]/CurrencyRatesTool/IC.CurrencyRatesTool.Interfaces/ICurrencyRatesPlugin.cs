using System.Collections.Generic;

namespace IC.CurrencyRatesTool.Interfaces
{
    /// <summary>
    /// Presents Currency Rates logic
    /// 
    /// 2017/08/26 - Created, VTyagunov
    /// </summary>
    public interface ICurrencyRatesPlugin
    {
        /// <summary>
        /// Use for Get Currency Rates from web
        /// </summary>
        /// <returns></returns>
        Dictionary<string, decimal> Get(); 
    }
}