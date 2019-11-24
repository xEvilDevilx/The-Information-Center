using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

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
    /// Implements Advertising business logic
    /// 
    /// 2017/01/30 - Created, VTyagunov
    /// </summary>
    public class Advertising : IAdvertising
    {
        #region Variables

        /// <summary>Presents Business Logic entry</summary>
        private IBusinessLogicEntry _businessLogicEntry;
        /// <summary>Presents PluginManager work</summary>
        private IPluginManager _pluginManager;
        /// <summary>Advertising Control</summary>
        private IAdvertisingControl _advertisingControl;
        /// <summary>Advertisement identificator</summary>
        private int _advertisementIdInList;
        /// <summary>Change advertising timer</summary>
        private System.Threading.Timer _timer;

        #endregion

        #region Properties

        /// <summary>Image bytes array list</summary>
        public List<byte[]> AdvertisingImageList { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="businessLogicEntry">Business Logic entry object</param>
        /// <param name="pluginManager">Plugin Manager object</param>
        public Advertising(IBusinessLogicEntry businessLogicEntry, 
            IPluginManager pluginManager)
        {
            Logger.Log.Debug("Advertising. Ctr. Enter");

            if (businessLogicEntry == null)
                throw new ArgumentNullException("businessLogicEntry");

            if (pluginManager == null)
                throw new ArgumentNullException("pluginManager");

            _businessLogicEntry = businessLogicEntry;
            _pluginManager = pluginManager;
            _advertisingControl = 
                (IAdvertisingControl)_pluginManager.ControlsDictionary[UserControlTypes.Advertising];
            _advertisingControl.KeyHook = _pluginManager.KeyHook;
            AdvertisingImageList = new List<byte[]>();
            _advertisementIdInList = 0;
            _advertisingControl.CloseControlEvent += ShowLastControl;

            Logger.Log.Debug("Advertising. Ctr. Exit");
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

            ChangeAdvertising(null);
            StartTimer();            
            _pluginManager.ShowControl(UserControlTypes.Advertising);

            Logger.Log.Debug("ShowControl. Exit");
        }

        /// <summary>
        /// Use for hide control
        /// </summary>
        public void HideControl()
        {
            Logger.Log.Debug("HideControl. Enter");

            StopTimer();
            _pluginManager.HideControl(UserControlTypes.Advertising);

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
        /// Use for start timer
        /// </summary>
        private void StartTimer()
        {
            Logger.Log.Debug("StartTimer. Enter");

            _timer = new System.Threading.Timer(ChangeAdvertising, null,
                BaseConstants.ADChangeIntervalValue, BaseConstants.ADChangeIntervalValue);

            Logger.Log.Debug("StartTimer. Exit");
        }

        /// <summary>
        /// Usw for stop timer
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
        /// Use for set advertising to ad image list
        /// </summary>
        /// <param name="advertisingData">Advertising Data object</param>
        public void Set(AdvertisingData advertisingData)
        {
            Logger.Log.Debug("Set. Enter");

            try
            {
                if ((advertisingData != null) && (advertisingData.Picture != null))
                    AdvertisingImageList.Add(advertisingData.Picture);

                Logger.Log.Debug("Set. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Set", ex);
            }
        }

        /// <summary>
        /// Use for change advertising image in control
        /// </summary>
        /// <param name="stateInfo"></param>
        private void ChangeAdvertising(object stateInfo)
        {
            Logger.Log.Debug("ChangeAdvertising. Enter");

            try
            {
                if (AdvertisingImageList.Count > 0)
                {
                    var imageStream = new MemoryStream(AdvertisingImageList[_advertisementIdInList]);
                    var image = new Bitmap(imageStream);

                    _advertisingControl.ChangeAdvertisement(image);

                    _advertisementIdInList++;
                    if (AdvertisingImageList.Count <= _advertisementIdInList)
                        _advertisementIdInList = 0;
                }

                Logger.Log.Debug("ChangeAdvertising. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("ChangeAdvertising.", ex);
            }
        }

        #endregion
    }
}