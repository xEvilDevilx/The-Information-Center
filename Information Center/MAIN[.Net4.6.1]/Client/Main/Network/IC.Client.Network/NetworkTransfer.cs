using System;
using System.Net;

using IC.Client.BusinessLogic.Interfaces;
using IC.Client.DataLayer;
using IC.Client.FormModel.Base.Enums;
using IC.Client.Network.Interfaces;
using IC.LicenseManager.CryptoService;
using IC.LicenseManager.Interfaces;
using IC.SDK;
using IC.SDK.Base.Constants;
using IC.SDK.Helpers;
using IC.SDK.Interfaces.Serialization;
using IC.SDK.Serialization;

namespace IC.Client.Network
{
    /// <summary>
    /// Presents work with Client DataLayer
    /// 
    /// 2017/03/02 - Created, VTyagunov
    /// </summary>
    internal class NetworkTransfer : INetworkTransfer
    {
        #region Variables

        /// <summary>Client Main Entry</summary>
        private IMainEntry _mainEntry;
        /// <summary>IC Serialization tool</summary>
        private IStreamSerializer _streamSerializer;
        /// <summary>IC Serialization tool</summary>
        private IBytesArraySerializer _bytesArraySerializer;
        /// <summary>Business Logic Entry</summary>
        private IBusinessLogicEntry _businessLogicEntry;
        /// <summary>License Verify work</summary>
        private ILicenseVerifier _licenseVerifier;

        #endregion

        #region Properties

        /// <summary>Store default language</summary>
        public string DefaultLanguage { get; set; }
        /// <summary>Store default currency</summary>
        public string DefaultCurrency { get; set; }
        /// <summary>Store current language</summary>
        public string CurrentLanguage { get; set; }
        /// <summary>Store current currency</summary>
        public string CurrentCurrency { get; set; }
        /// <summary>Flag to show Localized/Not Localized status</summary>
        public bool IsLocalized { get; private set; }
        /// <summary>Flag to show Logo Setted/Not Setted status</summary>
        public bool IsLogoSetted { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainEntry">Client Main Entry</param>
        public NetworkTransfer(IMainEntry mainEntry)
        {
            Logger.Log.Debug("NetworkTransfer. Ctr. Enter");

            if (mainEntry == null)
                throw new ArgumentNullException("mainEntry");

            IsLocalized = false;
            IsLogoSetted = false;
            _mainEntry = mainEntry;
            _streamSerializer = new Serializer();
            _bytesArraySerializer = new Serializer();
            _businessLogicEntry = _mainEntry.Logic;
            _licenseVerifier = new LicenseVerifier();
            _businessLogicEntry.Settings.SendLangCurrDataEvent += RequireLocalization;
            _businessLogicEntry.Scan.SendLangCurrDataEvent += RequireLocalization;

            Logger.Log.Debug("NetworkTransfer. Ctr. Exit");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for work bith received bytes array packet
        /// </summary>
        /// <param name="bytesArray">Bytes array packet</param>
        /// <returns></returns>
        public void UDPProcess(byte[] bytesArray)
        {
            Logger.Log.Debug("UDPProcess. Enter");

            try
            {
                var ipAddressString = (string)_bytesArraySerializer.DeserializeFromBytesArray(bytesArray);

                if (!string.IsNullOrEmpty(ipAddressString))
                {
                    var ipAddress = IPAddress.Parse(ipAddressString);
                    var endPoint = new IPEndPoint(ipAddress, BaseConstants.TcpServerPort);

                    _mainEntry.UdpNotification.StopSend();
                    _mainEntry.TcpService.Start(endPoint);
                }
                Logger.Log.Debug("UDPProcess. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UDPProcess.", ex);
            }
        }

        /// <summary>
        /// Use for work bith received packet object
        /// </summary>
        /// <param name="obj">Received packet object</param>
        public void TCPProcess(object obj)
        {
            try
            {
                Logger.Log.Debug("TCPProcess. Enter");

                if (obj is LicenseData)
                    CompleteLicenseVerify((LicenseData)obj);
                if (obj is DefaultLangCurr)
                    SetDefaultLangCurr((DefaultLangCurr)obj);
                if (obj is AdvertisingData)
                    _businessLogicEntry.Advertising.Set((AdvertisingData)obj);
                if (obj is SystemTranslationData)
                {
                    IsLocalized = _businessLogicEntry.SystemManager.
                        LocalizeControls((SystemTranslationData)obj);
                }
                if (obj is LanguageData)
                    SetLanguage((LanguageData)obj);
                if (obj is CurrencyData)
                    SetCurrency((CurrencyData)obj);
                if (obj is LogoData)
                {
                    IsLogoSetted = _businessLogicEntry.SystemManager.SetLogoToControls((LogoData)obj);
                    if (IsLocalized && IsLogoSetted)
                    {
                        _businessLogicEntry.ShowControl(UserControlTypes.Scan);
                    }
                    else
                    {
                        _mainEntry.TcpNotification.StopSend();
                        _mainEntry.UdpNotification.StartSend(BaseConstants.ClientSendInterval);
                        _businessLogicEntry.ShowControl(UserControlTypes.UnAvailable);
                    }
                }
                if (obj is ProductInfoData)
                    _businessLogicEntry.ProductInfo.Set((ProductInfoData)obj);
                if (obj is SharesSalesData)
                    _businessLogicEntry.SharesSales.AddSharesSalesData((SharesSalesData)obj);
                if (obj is ClientStatus)
                    CheckServerStatus((ClientStatus)obj);

                Logger.Log.Debug("TCPProcess. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("TCPProcess.", ex);
            }
        }

        /// <summary>
        /// Use for start UDP Notification thread
        /// </summary>
        public void StartUDPNotifyThread()
        {
            Logger.Log.Debug("StartUDPNotifyThread. Enter");

            _mainEntry.UdpNotification.StartSend(BaseConstants.ClientSendInterval);

            Logger.Log.Debug("StartUDPNotifyThread. Exit");
        }

        /// <summary>
        /// Use for start TCP License Verify thread
        /// </summary>
        public void StartTCPLicenseVerifyThread()
        {
            Logger.Log.Debug("StartTCPLicenseVerifyThread. Enter");

            _mainEntry.TcpLicenseVerify.StartSend(60);

            Logger.Log.Debug("StartTCPLicenseVerifyThread. Exit");
        }

        /// <summary>
        /// Use for start TCP Notification thread
        /// </summary>
        public void StartTCPNotifyThread()
        {
            Logger.Log.Debug("StartTCPNotifyThread. Enter");

            _mainEntry.TcpNotification.StartSend(BaseConstants.ClientSendInterval);

            Logger.Log.Debug("StartTCPNotifyThread. Exit");
        }

        /// <summary>
        /// Use for send Require Localization
        /// </summary>
        /// <param name="currencyCode">Currency code string</param>
        /// <param name="languageCode">Language code string</param>
        /// <param name="showOldControl">Flag to show/not show old control</param>
        private void RequireLocalization(string currencyCode, string languageCode, bool showOldControl)
        {
            Logger.Log.Debug("RequireLocalization. Enter");

            try
            {
                CurrentCurrency = currencyCode;
                CurrentLanguage = languageCode;

                _mainEntry.Requests.RequireDefaultLocalizationData(languageCode, currencyCode);

                if (!showOldControl)
                    _mainEntry.Requests.RequireDefaultSettings();
                else
                {
                    switch (_mainEntry.ControlsPlugin.LastControlType)
                    {
                        case UserControlTypes.ProductByShare:
                        case UserControlTypes.ProductInfo:
                            var barCodeData = _businessLogicEntry.ProductInfo.GetLastBarCode();
                            if (barCodeData != null)
                            {
                                _mainEntry.Requests.RequireProductInfo(barCodeData, languageCode,
                                    currencyCode);
                                return;
                            }
                            break;
                    }

                    _businessLogicEntry.ShowLastControl();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("RequireLocalization.", ex);
            }

            Logger.Log.Debug("RequireLocalization. Exit");
        }

        /// <summary>
        /// Use for Prepare to set Product Info
        /// </summary>
        /// <param name="productInfoData">Product Info data</param>
        private void PrepareToSetProductInfo(ProductInfoData productInfoData)
        {
            Logger.Log.Debug("PrepareToSetProductInfo. Enter");

            _businessLogicEntry.HideAllControls();

            try
            {
                _businessLogicEntry.ProductInfo.Set(productInfoData);

                Logger.Log.Debug("PrepareToSetProductInfo. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("PrepareToSetProductInfo.", ex);
            }
        }

        /// <summary>
        /// Use for Complete License Verify
        /// </summary>
        /// <param name="licenseData">License Data</param>
        private void CompleteLicenseVerify(LicenseData licenseData)
        {
            Logger.Log.Debug("CompleteLicenseVerify. Enter");

            var clientLicenseData = _licenseVerifier.GetClientLicenseDataFromKey(licenseData.LicenseDataArray);

            if (clientLicenseData.Password == "1")
                throw new ApplicationException("License is not valid!");

            var macAddress = Utils.GetMacAddress();

            if (clientLicenseData.MACAddress != macAddress)
                throw new ApplicationException("License is not valid! Wrong MAC Address!");

            if (clientLicenseData.UID != MainEntry._uniqueClientLicenseKey)
                throw new ApplicationException("License is not valid! Wrong Client UID.");

            if (clientLicenseData.Version != AssemblyWorker.Instance.Version)
                throw new ApplicationException("License is not valid! Client version are not equal Server version!");

            if (clientLicenseData.Password == BaseConstants.LicenseIsVerified)
            {
                _mainEntry.TcpLicenseVerify.StopSend();
                StartTCPNotifyThread();
            }
            else throw new ApplicationException("License is not valid! License key is not verified!");

            Logger.Log.Debug("CompleteLicenseVerify. Exit");
        }

        /// <summary>
        /// Use for Set default Language and Currency values
        /// </summary>
        /// <param name="defaultLangCurr">Default Language and Currency data</param>
        private void SetDefaultLangCurr(DefaultLangCurr defaultLangCurr)
        {
            Logger.Log.Debug("SetDefaultLangCurr. Enter");

            if (!string.IsNullOrEmpty(defaultLangCurr.Language))
            {
                DefaultLanguage = defaultLangCurr.Language;
                CurrentLanguage = defaultLangCurr.Language;
            }
            else
            {
                DefaultLanguage = BaseConstants.DefaultLanguage;
                CurrentLanguage = BaseConstants.DefaultLanguage;
            }
            if (!string.IsNullOrEmpty(defaultLangCurr.Currency))
            {
                DefaultCurrency = defaultLangCurr.Currency;
                CurrentCurrency = defaultLangCurr.Currency;
            }
            else
            {
                DefaultCurrency = BaseConstants.DefaultCurrency;
                CurrentCurrency = BaseConstants.DefaultCurrency;
            }

            Logger.Log.Debug("SetDefaultLangCurr. Exit");
        }

        /// <summary>
        /// Use for Set Language value
        /// </summary>
        /// <param name="languageData">Language Data</param>
        private void SetLanguage(LanguageData languageData)
        {
            Logger.Log.Debug("SetLanguage. Enter");

            try
            {
                _businessLogicEntry.Settings.AddItemToLanguageListView(languageData);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("SetLanguage.", ex);
            }

            Logger.Log.Debug("SetLanguage. Exit");
        }

        /// <summary>
        /// Use for Set Currency value
        /// </summary>
        /// <param name="currencyData">Currency Data</param>
        private void SetCurrency(CurrencyData currencyData)
        {
            Logger.Log.Debug("SetCurrency. Enter");

            try
            {
                _businessLogicEntry.Settings.AddItemToCurrencyListView(currencyData);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("SetCurrency.", ex);
            }

            Logger.Log.Debug("SetCurrency. Exit");
        }

        /// <summary>
        /// Use for Check Server Connection Status
        /// </summary>
        /// <param name="status">ClientStatus data</param>
        private void CheckServerStatus(ClientStatus status)
        {
            Logger.Log.Debug("CheckServerStatus. Enter");

            if ((status != null) && (status.isOnLine))
                _mainEntry.TcpService.IsConnected = true;
            else _mainEntry.TcpService.IsConnected = false;

            Logger.Log.Debug("CheckServerStatus. Exit");
        }

        /// <summary>
        /// Use for hide all control
        /// </summary>
        public void HideAllControls()
        {
            Logger.Log.Debug("HideAllControls. Enter");

            try
            {
                _businessLogicEntry.HideAllControls();

                Logger.Log.Debug("HideAllControls. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("HideAllControls.", ex);
            }
        }

        #endregion
    }
}