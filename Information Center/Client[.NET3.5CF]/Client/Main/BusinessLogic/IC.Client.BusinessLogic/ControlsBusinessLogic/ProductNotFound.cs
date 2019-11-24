using System;

using IC.Client.BusinessLogic.Interfaces;
using IC.Client.BusinessLogic.Interfaces.ControlsBusinessLogic;
using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Interfaces;
using IC.SDK;
using IC.SDK.Base;

namespace IC.Client.BusinessLogic.ControlsBusinessLogic
{
    /// <summary>
    /// ProductNotFound business logic
    /// 
    /// 2017/02/04 - Created, VTyagunov
    /// </summary>
    public class ProductNotFound : IProductNotFound
    {
        #region Variables

        /// <summary>Presents Business Logic entry</summary>
        private IBusinessLogicEntry _businessLogicEntry;
        /// <summary>Presents PluginManager work</summary>
        private IPluginManager _pluginManager;
        /// <summary>ProductNotFound timeout timer</summary>
        private System.Threading.Timer _timer;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="businessLogicEntry">Business Logic Entry object</param>
        /// <param name="pluginManager">Plugin Manager object</param>
        public ProductNotFound(IBusinessLogicEntry businessLogicEntry, IPluginManager pluginManager)
        {
            Logger.Log.Debug("ProductNotFound. Ctr. Enter");

            if (businessLogicEntry == null)
                throw new ArgumentNullException("businessLogicEntry");

            if (pluginManager == null)
                throw new ArgumentNullException("pluginManager");

            _businessLogicEntry = businessLogicEntry;
            _pluginManager = pluginManager;

            Logger.Log.Debug("ProductNotFound. Ctr. Exit");
        }

        #endregion

        #region Methods

        #region IControlBusinessLogic

        /// <summary>
        /// Use for show control
        /// </summary>
        public void ShowControl()
        {
            Logger.Log.Debug("ShowControl. Enter");

            StartTimer();
            _pluginManager.ShowControl(UserControlTypes.ProductNotFound);

            Logger.Log.Debug("ShowControl. Exit");
        }

        /// <summary>
        /// Use for hide control
        /// </summary>
        public void HideControl()
        {
            Logger.Log.Debug("HideControl. Enter");

            StopTimer();
            _pluginManager.HideControl(UserControlTypes.ProductNotFound);

            Logger.Log.Debug("HideControl. Exit");
        }

        /// <summary>
        /// Use for show last visible control
        /// </summary>
        public void ShowLastControl()
        {
            Logger.Log.Debug("ShowLastControl. Enter");

            _businessLogicEntry.ShowControl(UserControlTypes.Scan);

            Logger.Log.Debug("ShowLastControl. Exit");
        }

        #endregion

        #region Timers

        /// <summary>
        /// Use for start ProductNotFound timer
        /// </summary>
        private void StartTimer()
        {
            Logger.Log.Debug("StartTimer. Enter");

            _timer = new System.Threading.Timer(QuitFromControl, null,
                BaseConstants.CloseProductNotFoundControlTimeOutValue, 0);

            Logger.Log.Debug("StartTimer. Exit");
        }

        /// <summary>
        /// Use for stop ProductNotFound timer
        /// </summary>
        private void StopTimer()
        {
            Logger.Log.Debug("StopTimer. Enter");

            if (_timer != null)
            {
                _timer.Dispose();
                _timer = null;
            }

            Logger.Log.Debug("StopTimer. Exit");
        }
        
        #endregion        
        
        /// <summary>
        /// Use for quit from control event
        /// </summary>
        /// <param name="stateInfo"></param>
        public void QuitFromControl(object stateInfo)
        {
            Logger.Log.Debug("QuitFromControl. Enter");

            ShowLastControl();

            Logger.Log.Debug("QuitFromControl. Exit");
        }

        #endregion     
    }
}