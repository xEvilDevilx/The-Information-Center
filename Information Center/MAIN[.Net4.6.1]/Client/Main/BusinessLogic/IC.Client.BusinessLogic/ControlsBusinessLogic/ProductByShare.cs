using System;

using IC.Client.BusinessLogic.Interfaces;
using IC.Client.BusinessLogic.Interfaces.ControlsBusinessLogic;
using IC.Client.DataLayer;
using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Interfaces;
using IC.Client.FormModel.Interfaces.ControlModel;
using IC.SDK;
using IC.SDK.Base.Constants;

namespace IC.Client.BusinessLogic
{
    /// <summary>
    /// ProductByShare business logic
    /// 
    /// 2017/02/04 - Created, VTyagunov
    /// </summary>
    public class ProductByShare : IProductByShare
    {
        #region Variables

        /// <summary>Presents Business Logic entry</summary>
        private IBusinessLogicEntry _businessLogicEntry;
        /// <summary>Presents PluginManager work</summary>
        private IPluginManager _pluginManager;
        /// <summary>ProductByShare timeout timer</summary>
        private System.Threading.Timer _timer;
        /// <summary>Product By Share control</summary>
        private IProductByShareControl _productByShareControl;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="businessLogicEntry">Business Logic Entry object</param>
        /// <param name="pluginManager">Plugin Manager object</param>
        public ProductByShare(IBusinessLogicEntry businessLogicEntry, IPluginManager pluginManager)
        {
            Logger.Log.Debug("ProductByShare. Ctr. Enter");

            if (businessLogicEntry == null)
                throw new ArgumentNullException("businessLogicEntry");

            if (pluginManager == null)
                throw new ArgumentNullException("pluginManager");

            _businessLogicEntry = businessLogicEntry;
            _pluginManager = pluginManager;
            _productByShareControl =
                (IProductByShareControl)_pluginManager.ControlsDictionary[UserControlTypes.ProductByShare];
            _productByShareControl.ClickControlEvent += ResetTimer;
            _productByShareControl.ClickButtonUpEvent += BtnUp;
            _productByShareControl.ClickButtonDownEvent += BtnDown;
            _productByShareControl.ClickButtonSettingsEvent += BtnSettings;
            _productByShareControl.ClickButtonBackEvent += BtnBack;

            Logger.Log.Debug("ProductByShare. Ctr. Exit");
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
            _pluginManager.ShowControl(UserControlTypes.ProductByShare);

            Logger.Log.Debug("ShowControl. Exit");
        }

        /// <summary>
        /// Use for hide control
        /// </summary>
        public void HideControl()
        {
            Logger.Log.Debug("HideControl. Enter");

            StopTimer();
            _pluginManager.HideControl(UserControlTypes.ProductByShare);

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
        /// Use for start ProductByShare timer
        /// </summary>
        private void StartTimer()
        {
            Logger.Log.Debug("StartTimer. Enter");

            _timer = new System.Threading.Timer(QuitFromControl, null,
                BaseConstants.CloseControlTimeOutValue, 0);

            Logger.Log.Debug("StartTimer. Exit");
        }

        /// <summary>
        /// Use for stop ProductByShare timer
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
        /// Use for reset ProductByShare timer
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
            _productByShareControl.BtnUp();

            Logger.Log.Debug("BtnUp. Exit");
        }

        /// <summary>
        /// Use for does button down action
        /// </summary> 
        private void BtnDown()
        {
            Logger.Log.Debug("BtnDown. Enter");

            ResetTimer();
            _productByShareControl.BtnDown();

            Logger.Log.Debug("BtnDown. Exit");
        }

        /// <summary>
        /// Use for show ProductInfo control
        /// </summary> 
        private void BtnBack()
        {
            Logger.Log.Debug("BtnBack. Enter");

            _businessLogicEntry.ShowControl(UserControlTypes.ProductInfo);

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
        /// Use for quit from control event
        /// </summary>
        /// <param name="stateInfo"></param>
        public void QuitFromControl(object stateInfo)
        {
            Logger.Log.Debug("QuitFromControl. Enter");

            ShowLastControl();

            Logger.Log.Debug("QuitFromControl. Exit");
        }

        /// <summary>
        /// Use for set data to ProductByShare control
        /// </summary>
        /// <param name="productInfoData">Product Info Data object</param>
        public void SetProductByShareData(ProductInfoData productInfoData)
        {
            Logger.Log.Debug("SetProductByShareData. Enter");

            try
            {
                _productByShareControl.ClearControlData();

                if (!string.IsNullOrEmpty(productInfoData.TextBoxVendorCode))
                    _productByShareControl.SetVendorCode(productInfoData.TextBoxVendorCode);
                else _productByShareControl.SetVendorCode("Information missing");

                if (!string.IsNullOrEmpty(productInfoData.ProductSharesDesriptions))
                    _productByShareControl.SetProductByShareInfo(productInfoData.ProductSharesDesriptions);
                else _productByShareControl.SetProductByShareInfo("No product info");

                if (!string.IsNullOrEmpty(productInfoData.ProductSharesNames))
                    _productByShareControl.SetProductName(productInfoData.ProductSharesNames);
                else _productByShareControl.SetProductName("information missing");

                if (!string.IsNullOrEmpty(productInfoData.TextBoxBarCode))
                    _productByShareControl.SetBarCode(productInfoData.TextBoxBarCode);
                else _productByShareControl.SetBarCode("information missing");

                if (!string.IsNullOrEmpty(productInfoData.TextBoxPrice))
                    _productByShareControl.SetPrice(productInfoData.TextBoxPrice);
                else _productByShareControl.SetPrice("information missing");

                Logger.Log.Debug("SetProductByShareData. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("SetProductByShareData.", ex);
            }
        }

        #endregion
    }
}