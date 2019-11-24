using System.Windows.Forms;

using IC.CurrencyRatesTool.Interfaces;
using IC.CurrencyRatesTool.MainWorker;
using IC.DB.ICSQL.MSSQL.DataProvider;
using IC.DB.Interfaces;

namespace IC.CurrencyRatesTool.View.Forms
{
    /// <summary>
    /// Presents Currency Rates Main Form functionality
    /// 
    /// 2017/04/17 - Created, VTyagunov
    /// </summary>
    public partial class CurrencyRatesMainForm : Form
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
        public CurrencyRatesMainForm()
        {
            InitializeComponent();

            _pluginManager = new PluginManager();
            _icDBOperations = new DBOperations();
            _currencyRatesUpdater = new CurrencyRatesUpdater(_pluginManager, _icDBOperations);
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        /// <summary>
        /// Use for Start Updater
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, System.EventArgs e)
        {
            _currencyRatesUpdater.StartUpdater();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            tbStatus.Text = "Started";
        }

        /// <summary>
        /// Use for Stop Updater
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, System.EventArgs e)
        {
            _currencyRatesUpdater.StopUpdater();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            tbStatus.Text = "Stopped";
        }
    }
}