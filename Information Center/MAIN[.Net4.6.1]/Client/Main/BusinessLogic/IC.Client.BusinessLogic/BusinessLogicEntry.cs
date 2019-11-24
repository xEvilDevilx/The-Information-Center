using System;

using IC.Client.BusinessLogic.Interfaces;
using IC.Client.BusinessLogic.Interfaces.ControlsBusinessLogic;
using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Interfaces;
using IC.SDK;

namespace IC.Client.BusinessLogic
{
    /// <summary>
    /// Presents Business logic Entry
    /// 
    /// 2017/03/19 - Created, VTyagunov
    /// </summary>
    public class BusinessLogicEntry : IBusinessLogicEntry
    {
        #region Variables

        /// <summary>Old User Control Type</summary>
        private UserControlTypes _oldControlType;
        /// <summary>Current User Control Type</summary>
        private UserControlTypes _currentControlType;
        /// <summary>Plugin Manager</summary>
        private IPluginManager _pluginManager;

        #endregion

        #region Properties

        /// <summary>Presents Advertising business logic</summary>
        public IAdvertising Advertising { get; private set; }
        /// <summary>Presents Product By Share business logic</summary>
        public IProductByShare ProductByShare { get; private set; }
        /// <summary>Presents Product Info business logic</summary>
        public IProductInfo ProductInfo { get; private set; }
        /// <summary>Presents Product Not Found business logic</summary>
        public IProductNotFound ProductNotFound { get; private set; }
        /// <summary>Presents Scan business logic</summary>
        public IScan Scan { get; private set; }
        /// <summary>Presents Settings business logic</summary>
        public ISettings Settings { get; private set; }
        /// <summary>Presents Shares and Sales business logic</summary>
        public ISharesSales SharesSales { get; private set; }
        /// <summary>Presents System Manager business logic</summary>
        public ISystemManager SystemManager { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pluginManager">Plugin Manager object</param>
        public BusinessLogicEntry(IPluginManager pluginManager)
        {
            Logger.Log.Debug("BusinessLogicEntry. Ctr. Enter");

            if (pluginManager == null)
                throw new ArgumentNullException("pluginManager");

            _pluginManager = pluginManager;
            Advertising = new Advertising(this, pluginManager);
            ProductByShare = new ProductByShare(this, pluginManager);
            ProductInfo = new ProductInfo(this, pluginManager);
            ProductNotFound = new ProductNotFound(this, pluginManager);
            Scan = new Scan(this, pluginManager);
            Settings = new Settings(this, pluginManager);
            SharesSales = new SharesSales(this, pluginManager);
            SystemManager = new SystemManager(this, pluginManager);
            _oldControlType = UserControlTypes.UnAvailable;
            _currentControlType = UserControlTypes.UnAvailable;

            Logger.Log.Debug("BusinessLogicEntry. Ctr. Exit");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for show asigned control
        /// </summary>
        /// <param name="control">IControl object</param>
        public void ShowControl(UserControlTypes controlType)
        {
            Logger.Log.Debug("ShowControl. Enter");

            HideAllControls();
            _oldControlType = _currentControlType;

            switch (controlType)
            {
                case UserControlTypes.Advertising:
                    Advertising.ShowControl();
                    break;
                case UserControlTypes.ProductByShare:
                    ProductByShare.ShowControl();
                    break;
                case UserControlTypes.ProductInfo:
                    ProductInfo.ShowControl();
                    break;
                case UserControlTypes.ProductNotFound:
                    ProductNotFound.ShowControl();
                    break;
                case UserControlTypes.Scan:
                    Scan.ShowControl();
                    break;
                case UserControlTypes.Settings:
                    Settings.ShowControl();
                    break;
                case UserControlTypes.SharesSales:
                    SharesSales.ShowControl();
                    break;
                case UserControlTypes.UnAvailable:
                    _pluginManager.ShowControl(UserControlTypes.UnAvailable);
                    break;
            }
            
            _currentControlType = controlType;

            Logger.Log.Debug("ShowControl. Exit");
        }
        
        /// <summary>
        /// Use for hide all controls
        /// </summary>
        public void HideAllControls()
        {
            Logger.Log.Debug("HideAllControls. Enter");

            Advertising.HideControl();
            ProductByShare.HideControl();
            ProductInfo.HideControl();
            ProductNotFound.HideControl();
            Scan.HideControl();
            Settings.HideControl();
            SharesSales.HideControl();
            _pluginManager.HideControl(UserControlTypes.UnAvailable);

            Logger.Log.Debug("HideAllControls. Exit");
        }

        /// <summary>
        /// Use for Show Last Control
        /// </summary>
        public void ShowLastControl()
        {
            Logger.Log.Debug("ShowLastControl. Enter");

            ShowControl(_oldControlType);

            Logger.Log.Debug("ShowLastControl. Exit");
        }

        #endregion
    }
}