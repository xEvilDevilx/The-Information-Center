using System.ServiceProcess;

using IC.CurrencyRatesTool.Interfaces;
using IC.CurrencyRatesTool.MainWorker;
using IC.DB.ICSQL.MSSQL.DataProvider;
using IC.DB.Interfaces;
using IC.SDK;

namespace IC.CurrencyRatesTool.View.Service
{
    /// <summary>
    /// Presents Currency Rates Service
    /// 
    /// 2017/04/17 - Created, VTyagunov
    /// </summary>
    public partial class CurrencyRatesService : ServiceBase
    {
        /// <summary>Plugin Manager</summary>
        private readonly IPluginManager _pluginManager;
        /// <summary>IC DB Operations</summary>
        private readonly IICDBOperations _icDBOperations;
        /// <summary>Currency Rates Updater</summary>
        private ICurrencyRatesUpdater _currencyRatesUpdater;

        /// <summary>
        /// Constructor
        /// </summary>
        public CurrencyRatesService()
        {
            Logger.Log.Debug("CurrencyRatesUpdater. Ctr. Enter");

            InitializeComponent();

            _pluginManager = new PluginManager();
            _icDBOperations = new DBOperations();
            _currencyRatesUpdater = new CurrencyRatesUpdater(_pluginManager, _icDBOperations);

            Logger.Log.Debug("CurrencyRatesUpdater. Ctr. Exit");
        }

        /// <summary>
        /// Use for do Actions On Start
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            _currencyRatesUpdater.StartUpdater();
        }

        /// <summary>
        /// Use for do Actions On Stop
        /// </summary>
        protected override void OnStop()
        {
            _currencyRatesUpdater.StopUpdater();
        }
    }
}