using System;

namespace IC.SDK.Base
{
    /// <summary>
    /// All system's constants
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    public static class BaseConstants
    {
        /// <summary>Server DataLayer namespace name</summary>
        public const string ServerDataLayerNamespaceName = "IC.Client.DataLayer";
        /// <summary>Server DataLayer library name</summary>
        public const string ServerDataLayerLibName = "IC.Client.DataLayer";

//#if NETCF
//        /// <summary>Client DataLayer namespace name</summary>
//        public const string ClientDataLayerNamespaceName = "Kiosk.ClientDataLayer";
//        /// <summary>Client DataLayer library name</summary>
//        public const string ClientDataLayerLibName = "Kiosk.ClientDataLayer";
//#else
        /// <summary>Client DataLayer namespace name</summary>
        public const string ClientDataLayerNamespaceName = "IC.Client.DataLayer";
        /// <summary>Client DataLayer library name</summary>
        public const string ClientDataLayerLibName = "IC.Client.DataLayer";
//#endif

        /// <summary>ManagerLib namespace name</summary>
        public const string ManagerLibNamespaceName = "IC.ManagerLib";
        /// <summary>Tcp server port</summary>
        public const int TcpServerPort = 49500;
        /// <summary>Udp server port</summary>
        public const int UdpServerPort = 49501;
        /// <summary>Client Unique ID</summary>
        public static Guid ClientUID = new Guid("11f48831-02ac-485c-9010-b659fbdb36fa");
        /// <summary>Client send online status interval to server</summary>
        public const int ClientSendInterval = 15;

        #region Query's type commands 

        public static string[] TypeSplitter = new string[1] {"|||"};
        public const byte InterfaceTranslationType = 1;
        public const byte ProductInfoType = 2;
        public const byte AdvertisingType = 3;
        public const byte LanguageType = 4;
        public const byte CurrencyType = 5;
        public const byte LogoType = 6;
        public const byte SharesSalesType = 7;
        public const byte DefaultLangCurr = 8;

        #endregion

        /// <summary>Time rate for check "Signal" folder for a file with current name</summary>
        public const int CheckSignalFolderTimeRate = 60000;
        /// <summary>Signal file name, using for close Kiosk</summary>
        public const string SignalFolderName = "SignalFolder";
        /// <summary>Signal file name, using for close Kiosk</summary>
        public const string SignalFileName = "--CLOSE_KIOSK--.TXT";
        /// <summary>Client config xml name</summary>
        public const string ClientConfigXMLName = "Config.xml";
        /// <summary>Config plugin name</summary>
        public const string ConfigPluginName = "pluginName";
        /// <summary>Config Password</summary>
        public const string ConfigPasswordValue = "password";

        /// <summary>Presents advertising change interval</summary>
        public const int ADChangeIntervalValue = 10000;
        /// <summary>Timeout for hide control</summary>
        public const int CloseControlTimeOutValue = 30000;
        /// <summary>Timeout for hide ProductNotFound control</summary>
        public const int CloseProductNotFoundControlTimeOutValue = 5000;
        /// <summary>Images path</summary>
        public const string ImagesPath = "Images";
        /// <summary>NoImage file name</summary>
        public const string NoImageFileName = "imgNoImage.png";
        /// <summary>Default currency name</summary>
        public const string DefaultCurrency = "EUR";
        /// <summary>Default language name</summary>
        public const string DefaultLanguage = "ENG";
        /// <summary>License Is Verified Code</summary>
        public const string LicenseIsVerified = "Verified!";
    }
}