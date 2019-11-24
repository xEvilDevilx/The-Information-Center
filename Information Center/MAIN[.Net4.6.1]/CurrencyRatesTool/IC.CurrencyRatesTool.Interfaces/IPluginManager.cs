using System.Collections.Generic;

namespace IC.CurrencyRatesTool.Interfaces
{
    /// <summary>
    /// Presents work with plugins interface
    /// 
    /// 2017/08/26 - Created, VTyagunov
    /// </summary>
    public interface IPluginManager
    {
        /// <summary>Store Currency Rate Plugins</summary>
        Dictionary<string, ICurrencyRatesPlugin> CurrencyRatePlugins { get; }
    }
}