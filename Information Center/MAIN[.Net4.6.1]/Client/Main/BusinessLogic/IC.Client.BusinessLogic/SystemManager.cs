using System;
using System.Drawing;
using System.IO;

using IC.Client.BusinessLogic.Interfaces;
using IC.Client.DataLayer;
using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Interfaces;
using IC.Client.FormModel.Interfaces.ControlModel;
using IC.SDK;

namespace IC.Client.BusinessLogic
{
    /// <summary>
    /// Presents System Manager for manage system data(Logotypes, localizations, etc)
    /// 
    /// 2017/02/18 - Created, VTyagunov
    /// </summary>
    public class SystemManager : ISystemManager
    {
        #region Variables

        /// <summary>Presents PluginManager work</summary>
        private IPluginManager _pluginManager;
        /// <summary>Business Logic Entry</summary>
        private IBusinessLogicEntry _businessLogicEntry;
        /// <summary>Presents Product By Share control</summary>
        private IProductByShareControl _productByShareControl;
        /// <summary>Presents Product Info control</summary>
        private IProductInfoControl _productInfoControl;
        /// <summary>Presents Product Not Found control</summary>
        private IProductNotFoundControl _productNotFoundControl;
        /// <summary>Presents Scan control</summary>
        private IScanControl _scanControl;
        /// <summary>Presents Settings control</summary>
        private ISettingsControl _settingsControl;
        /// <summary>Presents Shares and Sales Control</summary>
        private ISharesSalesControl _sharesSalesControl;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="businessLogicEntry">Business Logic Entry object</param>
        /// <param name="pluginManager">Plugin Manager object</param>
        public SystemManager(IBusinessLogicEntry businessLogicEntry, IPluginManager pluginManager)
        {
            Logger.Log.Debug("SystemManager. Ctr. Enter");

            if (businessLogicEntry == null)
                throw new ArgumentNullException("businessLogicEntry");

            if (pluginManager == null)
                throw new ArgumentNullException("pluginManager");

            _businessLogicEntry = businessLogicEntry;
            _pluginManager = pluginManager;
            _productByShareControl =
                (IProductByShareControl)_pluginManager.ControlsDictionary[UserControlTypes.ProductByShare];
            _productInfoControl =
                (IProductInfoControl)_pluginManager.ControlsDictionary[UserControlTypes.ProductInfo];
            _productNotFoundControl =
                (IProductNotFoundControl)_pluginManager.ControlsDictionary[UserControlTypes.ProductNotFound];
            _scanControl =
                (IScanControl)_pluginManager.ControlsDictionary[UserControlTypes.Scan];
            _settingsControl =
                (ISettingsControl)_pluginManager.ControlsDictionary[UserControlTypes.Settings];
            _sharesSalesControl =
                (ISharesSalesControl)_pluginManager.ControlsDictionary[UserControlTypes.SharesSales];

            Logger.Log.Debug("SystemManager. Ctr. Exit");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for localize all system controls
        /// </summary>
        /// <param name="systemTranslationData">System Translation Data object</param>
        public bool LocalizeControls(SystemTranslationData systemTranslationData)
        {
            Logger.Log.Debug("LocalizeControls. Enter");

            try
            {
                _productByShareControl.Localize(systemTranslationData);
                _productInfoControl.Localize(systemTranslationData);
                _productNotFoundControl.Localize(systemTranslationData);
                _scanControl.Localize(systemTranslationData);
                _settingsControl.Localize(systemTranslationData);
                _sharesSalesControl.Localize(systemTranslationData);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("LocalizeControls", ex);
                return false;
            }

            Logger.Log.Debug("LocalizeControls. Exit");
            return true;
        }

        /// <summary>
        /// Use for set logo to all system controls
        /// </summary>
        /// <param name="logoData">Logo Data object</param>
        public bool SetLogoToControls(LogoData logoData)
        {
            Logger.Log.Debug("SetLogoToControls. Enter");

            try
            {
                var imageStream = new MemoryStream(logoData.LogoPicture);
                var image = new Bitmap(imageStream);

                _productByShareControl.SetLogoImage(image);
                _productInfoControl.SetLogoImage(image);
                _productNotFoundControl.SetLogoImage(image);
                _scanControl.SetLogoImage(image);
                _settingsControl.SetLogoImage(image);
                _sharesSalesControl.SetLogoImage(image);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("SetLogoToControls", ex);
                return false;
            }

            Logger.Log.Debug("SetLogoToControls. Exit");
            return true;
        }

        #endregion
    }
}