using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

using IC.CurrencyRatesTool.Interfaces;
using IC.SDK;
using IC.SDK.Base.Constants;

namespace IC.CurrencyRatesTool.MainWorker
{
    /// <summary>
    /// Implements work with plugins
    /// 
    /// 2017/08/26 - Created, VTyagunov
    /// </summary>
    public class PluginManager : IPluginManager
    {
        #region Variables
        
        /// <summary>ICurrencyRatesPlugin interface</summary>
        private readonly Dictionary<string, ICurrencyRatesPlugin> _currencyRatePlugins;

        #endregion

        #region Properties
        
        /// <summary>Store Currency Rate Plugins</summary>
        public Dictionary<string, ICurrencyRatesPlugin> CurrencyRatePlugins { get { return _currencyRatePlugins; } }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public PluginManager()
        {
            Logger.Log.Debug("PluginManager. Ctr. Enter");

            _currencyRatePlugins = new Dictionary<string, ICurrencyRatesPlugin>();
            LoadPlugins();

            Logger.Log.Debug("PluginManager. Ctr. Exit");
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Use for load ICurrencyRatesPlugin from plugin dll
        /// </summary>
        /// <param name="fileName">File Name</param>
        private ICurrencyRatesPlugin LoadAssemblies(string fileName)
        {
            Logger.Log.Debug("LoadAssemblies. Enter");

            try
            {
                var dirName = string.Format("{0}\\Plugins\\{1}.dll", Directory.GetCurrentDirectory(),
                    fileName);

                var assembly = Assembly.LoadFrom(dirName);
                if (assembly == null)
                    return null;

                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsClass)
                    {
                        var currencyRatesPluginInterface = type.GetInterface(nameof(ICurrencyRatesPlugin));
                        if (currencyRatesPluginInterface != null)
                        {
                            var currencyRatesPlugin = (ICurrencyRatesPlugin)Activator.CreateInstance(type);
                            return currencyRatesPlugin;
                        }
                    }
                }
                
                Logger.Log.Debug("LoadAssemblies. Exit");
                return null;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("LoadAssemblies. ", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for load plugin dll name from client config xml
        /// </summary>
        /// <returns></returns>
        private void LoadPlugins()
        {
            Logger.Log.Debug("LoadPlugins. Enter");

            try
            {
                var xml = XDocument.Load(BaseConstants.ClientConfigXMLName);
                var pluginNames = xml.Descendants(BaseConstants.ConfigPluginName);
                var currencyTypeAttrArray = pluginNames.Attributes("type").ToArray();
                int i = 0;
                foreach (var pluginName in pluginNames)
                {
                    var plugin = LoadAssemblies(pluginName.Value);
                    var currencyType = currencyTypeAttrArray[i].Value;
                    _currencyRatePlugins.Add(currencyType, plugin);
                    i++;
                }

                Logger.Log.Debug("LoadPlugins. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("LoadPlugins. ", ex);
                throw;
            }
        }
        
        #endregion
    }
}