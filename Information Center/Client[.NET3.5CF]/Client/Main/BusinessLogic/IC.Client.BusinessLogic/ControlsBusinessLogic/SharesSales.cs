using System;
using System.Collections.Generic;

using IC.Client.BusinessLogic.Interfaces;
using IC.Client.BusinessLogic.Interfaces.ControlsBusinessLogic;
using IC.Client.DataLayer;
using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Interfaces;
using IC.Client.FormModel.Interfaces.ControlModel;
using IC.SDK;
using IC.SDK.Base;

namespace IC.Client.BusinessLogic.ControlsBusinessLogic
{
    /// <summary>
    /// Shares and Sales business logic
    /// 
    /// 2017/02/26 - Created, VTyagunov
    /// </summary>
    public class SharesSales : ISharesSales
    {
        #region Variables

        /// <summary>Presents Business Logic entry</summary>
        private IBusinessLogicEntry _businessLogicEntry;
        /// <summary>Presents PluginManager work</summary>
        private IPluginManager _pluginManager;
        /// <summary>Shares and Sales control</summary>
        private ISharesSalesControl _sharesSalesControl;
        /// <summary>SharesSales control timeout timer</summary>
        private System.Threading.Timer _timer;
        /// <summary>Store Shares and Sales data list</summary>
        private List<SharesSalesData> _sharesSalesDataList;
        /// <summary>Store ID of current SharesSalesData</summary>
        private int _sharesSalesDataID;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="businessLogicEntry">Business Logic Entry object</param>
        /// <param name="pluginManager">Plugin Manager object</param>
        public SharesSales(IBusinessLogicEntry businessLogicEntry, IPluginManager pluginManager)
        {
            Logger.Log.Debug("SharesSales. Ctr. Enter");

            if (businessLogicEntry == null)
                throw new ArgumentNullException("businessLogicEntry");

            if (pluginManager == null)
                throw new ArgumentNullException("pluginManager");

            _businessLogicEntry = businessLogicEntry;
            _pluginManager = pluginManager;
            _sharesSalesControl =
                (ISharesSalesControl)_pluginManager.ControlsDictionary[UserControlTypes.SharesSales];
            _sharesSalesControl.KeyHook = pluginManager.KeyHook;
            _sharesSalesControl.ClickControlEvent += ResetTimer;
            _sharesSalesControl.ClickButtonUpEvent += BtnUp;
            _sharesSalesControl.ClickButtonDownEvent += BtnDown;
            _sharesSalesControl.ClickButtonSettingsEvent += BtnSettings;
            _sharesSalesControl.ClickButtonPreviousEvent += BtnPrevious;
            _sharesSalesControl.ClickButtonNextEvent += BtnNext;
            _sharesSalesControl.ClickButtonBackEvent += BtnBack;
            _sharesSalesDataList = new List<SharesSalesData>();
            _sharesSalesDataID = 0;

            Logger.Log.Debug("SharesSales. Ctr. Exit");
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
            _pluginManager.ShowControl(UserControlTypes.SharesSales);

            Logger.Log.Debug("ShowControl. Exit");
        }

        /// <summary>
        /// Use for hide control
        /// </summary>
        public void HideControl()
        {
            Logger.Log.Debug("HideControl. Enter");

            StopTimer();
            _pluginManager.HideControl(UserControlTypes.SharesSales);

            Logger.Log.Debug("HideControl. Exit");
        }

        /// <summary>
        /// Use for show last visible control
        /// </summary>
        public void ShowLastControl()
        {
            Logger.Log.Debug("ShowOldControl. Enter");

            _businessLogicEntry.ShowControl(UserControlTypes.Scan);

            Logger.Log.Debug("ShowOldControl. Exit");
        }

        #endregion

        #region Timers

        /// <summary>
        /// Use for start SharesSales control timer
        /// </summary>
        private void StartTimer()
        {
            Logger.Log.Debug("StartTimer. Enter");

            _timer = new System.Threading.Timer(ShowOldControl, null,
                BaseConstants.CloseControlTimeOutValue, 0);

            Logger.Log.Debug("StartTimer. Exit");
        }

        /// <summary>
        /// Use for stop SharesSales control timer
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
        /// Use for reset SharesSales control timer
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
        /// Use for does button up action
        /// </summary>  
        private void BtnUp()
        {
            Logger.Log.Debug("BtnUp. Enter");

            ResetTimer();
            _sharesSalesControl.BtnUp();

            Logger.Log.Debug("BtnUp. Exit");
        }

        /// <summary>
        /// Use for does button down action
        /// </summary> 
        private void BtnDown()
        {
            Logger.Log.Debug("BtnDown. Enter");

            ResetTimer();
            _sharesSalesControl.BtnDown();

            Logger.Log.Debug("BtnDown. Exit");
        }

        /// <summary>
        /// Use for does button previous action
        /// </summary>  
        private void BtnPrevious()
        {
            Logger.Log.Debug("BtnPrevious. Enter");

            ResetTimer();
            MathSharesSalesID(false);
            if ((_sharesSalesDataList != null) && (_sharesSalesDataList.Count > 0))
                _sharesSalesControl.SetSharesSalesData(_sharesSalesDataList[_sharesSalesDataID]);

            Logger.Log.Debug("BtnPrevious. Exit");
        }

        /// <summary>
        /// Use for does button next action
        /// </summary> 
        private void BtnNext()
        {
            Logger.Log.Debug("BtnNext. Enter");

            ResetTimer();
            MathSharesSalesID(true);
            if ((_sharesSalesDataList != null) && (_sharesSalesDataList.Count > 0))
                _sharesSalesControl.SetSharesSalesData(_sharesSalesDataList[_sharesSalesDataID]);

            Logger.Log.Debug("BtnNext. Exit");
        }

        /// <summary>
        /// Use for show ProductInfo control
        /// </summary> 
        private void BtnBack()
        {
            Logger.Log.Debug("BtnBack. Enter");

            _businessLogicEntry.ShowControl(UserControlTypes.Scan);

            Logger.Log.Debug("BtnBack. Exit");
        }

        /// <summary>
        /// Use for show Settings control
        /// </summary> 
        private void BtnSettings()
        {
            Logger.Log.Debug("BtnSettings. Enter");

            _businessLogicEntry.ShowControl(UserControlTypes.Settings);

            Logger.Log.Debug("BtnSettings. Exit");
        }

        #endregion

        /// <summary>
        /// Use for add AddSharesSalesData to collection
        /// </summary>
        /// <param name="sharesSalesData">Shares Sales Data object</param>
        public void AddSharesSalesData(SharesSalesData sharesSalesData)
        {
            Logger.Log.Debug("AddSharesSalesData. Enter");

            if (_sharesSalesDataList == null)
                _sharesSalesDataList = new List<SharesSalesData>();

            var isContains = false;
            int id = 0;

            for(int i = 0; i < _sharesSalesDataList.Count; i++)
            {                
                if (_sharesSalesDataList[i].SharesID == sharesSalesData.SharesID)
                {                    
                    isContains = true;
                    id = i;
                    break;
                }
            }
            
            if(!isContains)
                _sharesSalesDataList.Add(sharesSalesData);
            else
            {
                _sharesSalesDataList.RemoveAt(id);
                _sharesSalesDataList.Add(sharesSalesData);
            }

            if (_sharesSalesDataList.Count > 0)
                _sharesSalesControl.SetSharesSalesData(_sharesSalesDataList[0]);

            Logger.Log.Debug("AddSharesSalesData. Exit");
        }

        /// <summary>
        /// Use for clear SharesSalesData collection
        /// </summary>
        public void ClearSharesSalesData()
        {
            Logger.Log.Debug("ClearSharesSalesData. Enter");

            if (_sharesSalesDataList != null)
                _sharesSalesDataList.Clear();

            Logger.Log.Debug("ClearSharesSalesData. Exit");
        }

        /// <summary>
        /// Use for math next or previous SharesSalesID
        /// </summary>
        /// <param name="isNext">Flag to increment or decrement a shares and sales data ID</param>
        private void MathSharesSalesID(bool isNext)
        {
            Logger.Log.Debug("MathSharesSalesID. Enter");

            if (!isNext)
            {
                if (_sharesSalesDataID <= 0)
                    _sharesSalesDataID = _sharesSalesDataList.Count - 1;
                else _sharesSalesDataID--;
            }
            else
            {
                if (_sharesSalesDataID >= _sharesSalesDataList.Count - 1)
                    _sharesSalesDataID = 0;
                else _sharesSalesDataID++;
            }

            Logger.Log.Debug("MathSharesSalesID. Exit");
        }

        /// <summary>
        /// Use for show last visible control
        /// </summary>
        /// <param name="stateInfo">State info</param>
        private void ShowOldControl(object stateInfo)
        {
            Logger.Log.Debug("ShowOldControl. Enter");

            ShowLastControl();

            Logger.Log.Debug("ShowOldControl. Exit");
        }

        #endregion
    }
}