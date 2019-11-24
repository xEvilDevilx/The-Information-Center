using System;
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
    /// ProductInfo business logic
    /// 
    /// 2017/02/02 - Created, VTyagunov
    /// </summary>
    public class ProductInfo : IProductInfo
    {
        #region Variables

        /// <summary>Presents Business Logic entry</summary>
        private IBusinessLogicEntry _businessLogicEntry;
        /// <summary>Presents PluginManager work</summary>
        private IPluginManager _pluginManager;
        /// <summary>Product Info control</summary>
        private IProductInfoControl _productInfoControl;
        /// <summary>ProductInfo timeout timer</summary>
        private System.Threading.Timer _timer;
        /// <summary>Store current bar code</summary>
        private string _currentBarCode;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="businessLogicEntry">Business Logic Entry object</param>
        /// <param name="pluginManager">Plugin Manager object</param>
        public ProductInfo(IBusinessLogicEntry businessLogicEntry, IPluginManager pluginManager)
        {
            Logger.Log.Debug("ProductInfo. Ctr. Enter");

            if (businessLogicEntry == null)
                throw new ArgumentNullException("businessLogicEntry");

            if (pluginManager == null)
                throw new ArgumentNullException("pluginManager");

            _businessLogicEntry = businessLogicEntry;
            _pluginManager = pluginManager;
            _productInfoControl = 
                (IProductInfoControl)_pluginManager.ControlsDictionary[UserControlTypes.ProductInfo];
            _productInfoControl.KeyHook = _pluginManager.KeyHook;
            _productInfoControl.ClickControlEvent += ResetTimer;
            _productInfoControl.ClickButtonUpEvent += BtnUp;
            _productInfoControl.ClickButtonDownEvent += BtnDown;
            _productInfoControl.ClickButtonSettingsEvent += BtnSettings;
            _productInfoControl.ClickButtonSharesEvent += BtnShares;

            Logger.Log.Debug("ProductInfo. Ctr. Exit");
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
            _pluginManager.ShowControl(UserControlTypes.ProductInfo);

            Logger.Log.Debug("ShowControl. Exit");
        }

        /// <summary>
        /// Use for hide control
        /// </summary>
        public void HideControl()
        {
            Logger.Log.Debug("HideControl. Enter");

            StopTimer();
            _pluginManager.HideControl(UserControlTypes.ProductInfo);

            Logger.Log.Debug("HideControl. Exit");
        }

        /// <summary>
        /// Use for quit from control event
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
        /// Use for start ProductInfo timer
        /// </summary>
        private void StartTimer()
        {
            Logger.Log.Debug("StartTimer. Enter");

            _timer = new System.Threading.Timer(ShowOldControl, null,
                BaseConstants.CloseControlTimeOutValue, 0);

            Logger.Log.Debug("StartTimer. Exit");
        }

        /// <summary>
        /// Use for stop ProductInfo timer
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
        /// Use for reset ProductInfo timer
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
            _productInfoControl.BtnUp();

            Logger.Log.Debug("BtnUp. Exit");
        }

        /// <summary>
        /// Use for does button down action
        /// </summary> 
        private void BtnDown()
        {
            Logger.Log.Debug("BtnDown. Enter");

            ResetTimer();
            _productInfoControl.BtnDown();

            Logger.Log.Debug("BtnDown. Exit");
        }

        /// <summary>
        /// Use for show ProductByShare control
        /// </summary> 
        private void BtnShares()
        {
            Logger.Log.Debug("BtnShares. Enter");

            _businessLogicEntry.ShowControl(UserControlTypes.ProductByShare);

            Logger.Log.Debug("BtnShares. Exit");
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
        /// Use for show last visible control
        /// </summary>
        /// <param name="stateInfo"></param>
        public void ShowOldControl(object stateInfo)
        {
            Logger.Log.Debug("ShowOldControl. Enter");

            ShowLastControl();

            Logger.Log.Debug("ShowOldControl. Exit");
        }

        /// <summary>
        /// Use for set ProductInfo data to control
        /// </summary>
        /// <param name="advertisingData">ProductInfo Data object</param>
        public void Set(ProductInfoData productInfoData)
        {
            Logger.Log.Debug("Set. Enter");

            try
            {
                _businessLogicEntry.HideAllControls();

                if ((!string.IsNullOrEmpty(productInfoData.TextBoxBarCode)) ||
                    (!string.IsNullOrEmpty(productInfoData.TextBoxProductName)))
                {
                    _currentBarCode = productInfoData.TextBoxBarCode;
                    SetProductInfoData(productInfoData);
                    _businessLogicEntry.ProductByShare.SetProductByShareData(productInfoData);
                    _businessLogicEntry.ShowControl(UserControlTypes.ProductInfo); 
                }
                else
                {
                    _businessLogicEntry.ShowControl(UserControlTypes.ProductNotFound);
                }
                
                Logger.Log.Debug("Set. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Set", ex);
            }
        }

        /// <summary>
        /// Use for set data to ProductInfo control
        /// </summary>
        /// <param name="productInfoData">Product Info Data object</param>
        private void SetProductInfoData(ProductInfoData productInfoData)
        {
            Logger.Log.Debug("SetProductInfoData. Enter");

            try
            {
                StopTimer();
                _productInfoControl.ClearControlData();

                if (!string.IsNullOrEmpty(productInfoData.TextBoxVendorCode))
                    _productInfoControl.SetVendorCode(productInfoData.TextBoxVendorCode);
                else _productInfoControl.SetVendorCode("Information missing");

                if (!string.IsNullOrEmpty(productInfoData.TextBoxProductInfo))
                    _productInfoControl.SetProductInfo(productInfoData.TextBoxProductInfo);
                else _productInfoControl.SetProductInfo("No product info");

                if (!string.IsNullOrEmpty(productInfoData.TextBoxProductName))
                    _productInfoControl.SetProductName(productInfoData.TextBoxProductName);
                else _productInfoControl.SetProductName("information missing");

                if (!string.IsNullOrEmpty(productInfoData.TextBoxBarCode))
                    _productInfoControl.SetBarCode(productInfoData.TextBoxBarCode);
                else _productInfoControl.SetBarCode("information missing");

                if (!string.IsNullOrEmpty(productInfoData.TextBoxPrice))
                    _productInfoControl.SetPrice(productInfoData.TextBoxPrice);
                else _productInfoControl.SetPrice("information missing");

                if ((productInfoData.PictureBoxProductImage != null) ||
                    (productInfoData.PictureBoxProductImage.Length != 0))
                {
                    var imageStream = new MemoryStream(productInfoData.PictureBoxProductImage);
                    var image = new System.Drawing.Bitmap(imageStream);
                    if (image != null)
                        _productInfoControl.SetProductImage(image);
                }
                else
                {
                    var filePath = string.Format("{0}\\{1}", BaseConstants.ImagesPath, BaseConstants.NoImageFileName);
                    var imageStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    var image = new System.Drawing.Bitmap(imageStream);

                    if (image != null)
                        _productInfoControl.SetProductImage(image);
                    else _productInfoControl.SetProductNoImage();
                }

                if (!string.IsNullOrEmpty(productInfoData.ProductSharesNames))
                    _productInfoControl.SetBtnSharesVisibility(true);
                else _productInfoControl.SetBtnSharesVisibility(false);

                Logger.Log.Debug("SetProductInfoData. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("SetProductInfoData.", ex);
            }
        }

        /// <summary>
        /// Use for get last bar code
        /// </summary>
        /// <returns></returns>
        public string GetLastBarCode()
        {
            Logger.Log.Debug("GetLastBarCode. Enter/Exit");

            if (!string.IsNullOrEmpty(_currentBarCode))
                return _currentBarCode;
            else return string.Empty;
        }

        #endregion
    }
}