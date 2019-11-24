using System;

using IC.Client.BusinessLogic.Interfaces;
using IC.Client.BusinessLogic.Interfaces.ControlsBusinessLogic;
using IC.Client.FormModel.Base.Enums;
using static IC.Client.FormModel.Base.EventHandlers.ControlEventHandlers;
using IC.Client.FormModel.Interfaces;
using IC.Client.FormModel.Interfaces.ControlModel;
using IC.SDK;
using IC.SDK.Base.Constants;

namespace IC.Client.BusinessLogic
{
    /// <summary>
    /// Scan business logic
    /// 
    /// 2017/02/19 - Created, VTyagunov
    /// </summary>
    public class Scan : IScan
    {
        #region Events

        /// <summary>Send Language and Currency Data Event</summary>
        public event SendLangCurrDataEventHandler SendLangCurrDataEvent;

        #endregion

        #region Variables

        /// <summary>Presents Business Logic entry</summary>
        private IBusinessLogicEntry _businessLogicEntry;
        /// <summary>Presents PluginManager work</summary>
        private IPluginManager _pluginManager;
        /// <summary>Scan control</summary>
        private IScanControl _scanControl;
        /// <summary>Scan control timeout timer</summary>
        private System.Threading.Timer _timer;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="businessLogicEntry">Business Logic Entry object</param>
        /// <param name="pluginManager">Plugin Manager object</param>
        public Scan(IBusinessLogicEntry businessLogicEntry, IPluginManager pluginManager)
        {
            Logger.Log.Debug("Scan. Ctr. Enter");

            if (businessLogicEntry == null)
                throw new ArgumentNullException("businessLogicEntry");

            if (pluginManager == null)
                throw new ArgumentNullException("pluginManager");

            _businessLogicEntry = businessLogicEntry;
            _pluginManager = pluginManager;
            _scanControl =
                (IScanControl)_pluginManager.ControlsDictionary[UserControlTypes.Scan];
            _scanControl.ClickControlEvent += ResetTimer;
            _scanControl.ClickButtonSettingsEvent += BtnSettings;
            _scanControl.ClickButtonSharesEvent += BtnShares;

            Logger.Log.Debug("Scan. Ctr. Exit");
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
            _pluginManager.ShowControl(UserControlTypes.Scan);

            Logger.Log.Debug("ShowControl. Exit");
        }

        /// <summary>
        /// Use for hide control
        /// </summary>
        public void HideControl()
        {
            Logger.Log.Debug("HideControl. Enter");

            StopTimer();
            _pluginManager.HideControl(UserControlTypes.Scan);

            Logger.Log.Debug("HideControl. Exit");
        }

        /// <summary>
        /// Use for show last visible control
        /// </summary>
        public void ShowLastControl()
        {
            Logger.Log.Debug("ShowLastControl. Enter");

            _pluginManager.ShowLastControl();

            Logger.Log.Debug("ShowLastControl. Exit");
        }

        #endregion

        #region Timers

        /// <summary>
        /// Use for start Scan control timer
        /// </summary>
        private void StartTimer()
        {
            Logger.Log.Debug("StartTimer. Enter");

            _timer = new System.Threading.Timer(ShowAdvertising, null,
                BaseConstants.CloseControlTimeOutValue, 0);

            Logger.Log.Debug("StartTimer. Exit");
        }

        /// <summary>
        /// Use for stop Scan control timer
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

        /// <summary>
        /// Use for reset Scan control timer
        /// </summary>
        private void ResetTimer()
        {
            Logger.Log.Debug("ResetTimer. Enter");

            StopTimer();
            StartTimer();

            Logger.Log.Debug("ResetTimer. Exit");
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Use for show Settings control
        /// </summary> 
        private void BtnSettings()
        {
            Logger.Log.Debug("BtnSettings. Enter");

            _businessLogicEntry.ShowControl(UserControlTypes.Settings);

            Logger.Log.Debug("BtnSettings. Exit");
        }

        /// <summary>
        /// Use for show SharesSales control
        /// </summary> 
        private void BtnShares()
        {
            Logger.Log.Debug("Shares_Click. Enter");

            _businessLogicEntry.ShowControl(UserControlTypes.SharesSales);

            Logger.Log.Debug("Shares_Click. Exit");
        }

        #endregion

        /// <summary>
        /// Use for show Advertising control event
        /// </summary>
        /// <param name="stateInfo"></param>
        private void ShowAdvertising(object stateInfo)
        {
            Logger.Log.Debug("ShowAdvertising. Enter");

            _businessLogicEntry.ShowControl(UserControlTypes.Advertising);
            ResetLocalization(string.Empty, string.Empty, false);

            Logger.Log.Debug("ShowAdvertising. Exit");
        }

        /// <summary>
        /// Use for requare localization
        /// </summary>
        /// <param name="currencyCode">Currency code</param>
        /// <param name="languageCode">Language code</param>
        /// <param name="isShowOldControl">Flag to show/not show old control</param>
        private void ResetLocalization(string currencyCode, string languageCode, bool isShowOldControl)
        {
            Logger.Log.Debug("ResetLocalization. Enter");

            if (SendLangCurrDataEvent != null)
                SendLangCurrDataEvent.Invoke(currencyCode, languageCode, isShowOldControl);

            Logger.Log.Debug("ResetLocalization. Exit");
        }

        #endregion
    }
}