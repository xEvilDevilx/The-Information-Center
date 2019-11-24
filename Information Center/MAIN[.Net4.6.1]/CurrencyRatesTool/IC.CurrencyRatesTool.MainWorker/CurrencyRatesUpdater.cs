using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using IC.CurrencyRatesTool.Interfaces;
using IC.DB.Base;
using IC.DB.DataLayer;
using IC.DB.Interfaces;
using IC.SDK;
using IC.SDK.Base.Constants;
using IC.SDK.Helpers;

namespace IC.CurrencyRatesTool.MainWorker
{
    /// <summary>
    /// Implements Currency Rates Updater work
    /// 
    /// 2017/04/17 - Created, VTyagunov
    /// </summary>
    public class CurrencyRatesUpdater : ICurrencyRatesUpdater
    {
        #region Variables

        /// <summary>Plugin Manager</summary>
        private readonly IPluginManager _pluginManager;
        /// <summary>Simple Timer</summary>
        private readonly SimpleTimer _timer;
        /// <summary>IC DB Operations</summary>
        private readonly IICDBOperations _icDBOperations;
        /// <summary>List of the Store Config data</summary>
        private readonly List<Config> _storeConfigList;
        /// <summary>Time interval which Updater using for start Currency Rates Update</summary>
        private readonly int _updateCurrencyRatesTimeInterval;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pluginManager">Plugin Manager</param>
        /// <param name="icDBOperations">IC DB Operations</param>
        public CurrencyRatesUpdater(IPluginManager pluginManager, IICDBOperations icDBOperations)
        {
            Logger.Log.Debug("CurrencyRatesUpdater. Ctr. Enter");

            if (pluginManager == null)
                throw new ArgumentNullException(nameof(pluginManager));

            if (icDBOperations == null)
                throw new ArgumentNullException(nameof(icDBOperations));

            _pluginManager = pluginManager;
            _timer = new SimpleTimer();
            _icDBOperations = icDBOperations;
            _storeConfigList = _icDBOperations.GetStoreCurrencyConfigList<Config>();
            _updateCurrencyRatesTimeInterval = ReadUpdateCurrencyRatesTimeInterval();

            Logger.Log.Debug("CurrencyRatesUpdater. Ctr. Exit");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for load plugin dll name from client config xml
        /// </summary>
        /// <returns></returns>
        private int ReadUpdateCurrencyRatesTimeInterval()
        {
            Logger.Log.Debug("ReadUpdateCurrencyRatesTimeInterval. Enter");

            try
            {
                var xml = XDocument.Load(BaseConstants.ClientConfigXMLName);
                var element = xml.Descendants(Constants.UpdateCurrencyRatesTimeInterval).First();
                                
                Logger.Log.Debug("ReadUpdateCurrencyRatesTimeInterval. Exit");
                return int.Parse(element.Value);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("ReadUpdateCurrencyRatesTimeInterval. ", ex);
                return Constants.DefaultUpdateCurrencyRatesTimeInterval;
            }
        }

        /// <summary>
        /// Use for check contains currency rates current currency rate
        /// </summary>
        /// <param name="currencyRate">Currency Rate to check</param>
        /// <param name="storeID">Store ID</param>
        /// <returns></returns>
        private bool Contains(CurrencyRate currencyRate, string storeID)
        {
            Logger.Log.Debug("Contains. Enter/Exit");

            var currRate = _icDBOperations.
                GetCurrencyRate<CurrencyRate>(storeID, currencyRate.CurrencyCode);
            if (currRate != null)
                return true;
            else return false;
        }

        /// <summary>
        /// Use for Update Currency Rate
        /// </summary>
        /// <param name="currencyRate">New Currency Rate</param>
        private void UpdateCurrencyRate(CurrencyRate currencyRate)
        {
            Logger.Log.Debug("UpdateCurrencyRate. Enter");

            var currentCurrency = _icDBOperations.GetCurrencyRate<CurrencyRate>(
                currencyRate.StoreID, currencyRate.CurrencyCode);
            currentCurrency.DateBegin = currencyRate.DateBegin;
            currentCurrency.RateValue = currencyRate.RateValue;
            _icDBOperations.UpdateCurrencyRate(currentCurrency);

            Logger.Log.Debug("UpdateCurrencyRate. Exit");
        }

        /// <summary>
        /// Use for Add Currency Rate
        /// </summary>
        /// <param name="currencyRate">New Currency Rate</param>
        private void AddCurrencyRate(CurrencyRate currencyRate)
        {
            Logger.Log.Debug("AddCurrencyRate. Enter");

            var queryData = new QueryData<CurrencyRate>()
            {
                QueryObject = currencyRate
            };
            _icDBOperations.Add(queryData);

            Logger.Log.Debug("AddCurrencyRate. Exit");
        }

        /// <summary>
        /// Use for Start Updater
        /// </summary>
        public void StartUpdater()
        {
            Logger.Log.Debug("StartUpdater. Enter");

            Utils.StartSimpleThread(() =>
            {
                _timer.Start(1, () =>
                {
                    Update();
                    _timer.Stop();
                });

                _timer.Start(_updateCurrencyRatesTimeInterval, () =>
                {
                    Update();
                });
            });

            Logger.Log.Debug("StartUpdater. Exit");
        }

        /// <summary>
        /// Use for Stop Updater
        /// </summary>
        public void StopUpdater()
        {
            Logger.Log.Debug("StopUpdater. Enter");

            _timer.Stop();

            Logger.Log.Debug("StopUpdater. Exit");
        }

        /// <summary>
        /// Use for Update Currency Rates
        /// </summary>
        public void Update()
        {
            Logger.Log.Debug("Update. Enter");

            try
            {
                foreach (var storeConfig in _storeConfigList)
                {
                    var currencyRates = _pluginManager.CurrencyRatePlugins[storeConfig.ConfigValue].Get();
                    var currencyRatesKeys = currencyRates.Keys;
                    foreach (var key in currencyRatesKeys)
                    {
                        var currencyRate = new CurrencyRate()
                        {
                            CurrencyCode = key,
                            DateBegin = DateTime.Now,
                            RateValue = currencyRates[key],
                            StoreID = storeConfig.StoreID
                        };
                        if (Contains(currencyRate, storeConfig.StoreID))
                            UpdateCurrencyRate(currencyRate);
                        else AddCurrencyRate(currencyRate);
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.Log.Error("Update. ", ex);
            }

            Logger.Log.Debug("Update. Exit");
        }

        #endregion
    }
}