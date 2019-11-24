using System;

using IC.Client.DataLayer;
using IC.Client.Network.Interfaces;
using IC.SDK;
using IC.SDK.Base;
using IC.SDK.Base.Enums;

namespace IC.Client.Network
{
    /// <summary>
    /// Implements work with data requests
    /// 
    /// 2017/01/29 - Created, VTyagunov
    /// </summary>
    public class NetworkRequests : INetworkRequests
    {
        #region Variables

        /// <summary>Client Main Entry</summary>
        private IMainEntry _mainEntry;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainEntry">Client Main Entry</param>
        public NetworkRequests(IMainEntry mainEntry)
        {
            Logger.Log.Debug("NetworkRequests. Ctr. Enter");

            if (mainEntry == null)
                throw new ArgumentNullException("mainEntry");

            _mainEntry = mainEntry;

            Logger.Log.Debug("NetworkRequests. Ctr. Exit");
        }

        #endregion

        #region Methods

        #region Requests

        /// <summary>
        /// Use for send system date require
        /// </summary>
        public void RequireSystemData()
        {
            Logger.Log.Debug("RequireSystemData. Enter");

            try
            {
                RequireAdvertising();
                RequireDefaultLocalizationData(string.Empty, string.Empty);
                RequireDefaultSettings();
                RequireLogo();

                Logger.Log.Debug("RequireSystemData. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("RequireSystemData", ex);
            }
        }

        /// <summary>
        /// Use for send default localization require
        /// </summary>
        /// <param name="languageCode">Language code string</param>
        /// <param name="currencyCode">Currency code string</param>
        public void RequireDefaultLocalizationData(string languageCode, string currencyCode)
        {
            Logger.Log.Debug("RequireDefaultLocalizationData. Enter");

            try
            {
                var shares = _mainEntry.Logic.SharesSales;
                if (shares == null)
                {
                    Logger.Log.Warn("RequireDefaultLocalizationData. SharesSales is null");
                    return;
                }

                var settings = _mainEntry.Logic.Settings;
                if (settings == null)
                {
                    Logger.Log.Warn("RequireDefaultLocalizationData. Settings is null");
                    return;
                }

                RequireLocalization(languageCode);

                shares.ClearSharesSalesData();

                RequireShares(languageCode);

                settings.ClearLanguageList();
                settings.ClearCurrencyList();

                RequireLanguage(languageCode);
                RequireCurrency(languageCode);

                Logger.Log.Debug("RequireDefaultLocalizationData. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("RequireDefaultLocalizationData", ex);
            }
        }

        /// <summary>
        /// Use for send localization require
        /// </summary>
        private bool RequireAdvertising()
        {
            Logger.Log.Debug("RequireAdvertising. Enter");

            var dbQuery = new DBQuery()
            {
                PacketType = BaseConstants.AdvertisingType,
                QueryString = ""
            };

            var tcpData = new TCPData()
            {
                Query = dbQuery,
                TcpTypes = TcpSerializeTypes.DBQuery
            };

            if (!SendTCPData(tcpData))
            {
                Logger.Log.Warn("RequireAdvertising. Server is unavailabe!");
                return false;
            }

            Logger.Log.Debug("RequireAdvertising. Exit");
            return true;
        }

        /// <summary>
        /// Use for send localization require
        /// </summary>
        /// <param name="languageCode">Language code string</param>
        /// <returns></returns>
        public bool RequireLocalization(string languageCode)
        {
            Logger.Log.Debug("RequireLocalization. Enter");

            var dbQuery = new DBQuery()
            {
                PacketType = BaseConstants.InterfaceTranslationType,
                QueryString = languageCode
            };

            var tcpData = new TCPData()
            {
                Query = dbQuery,
                TcpTypes = TcpSerializeTypes.DBQuery
            };

            if (!SendTCPData(tcpData))
            {
                Logger.Log.Warn("RequireLocalization. Server is unavailabe!");
                return false;
            }

            Logger.Log.Debug("RequireLocalization. Exit");
            return true;
        }

        /// <summary>
        /// Use for send default settings require
        /// </summary>
        /// <returns></returns>
        public bool RequireDefaultSettings()
        {
            Logger.Log.Debug("RequireDefaultSettings. Enter");

            var dbQuery = new DBQuery()
            {
                PacketType = BaseConstants.DefaultLangCurr,
                QueryString = string.Empty
            };

            var tcpData = new TCPData()
            {
                Query = dbQuery,
                TcpTypes = TcpSerializeTypes.DBQuery
            };

            if (!SendTCPData(tcpData))
            {
                Logger.Log.Warn("RequireDefaultSettings. Server is unavailabe!");
                return false;
            }

            Logger.Log.Debug("RequireDefaultSettings. Exit");
            return true;
        }

        /// <summary>
        /// Use for send logo require
        /// </summary>
        /// <returns></returns>
        private bool RequireLogo()
        {
            Logger.Log.Debug("RequireLogo. Enter");

            var dbQuery = new DBQuery()
            {
                PacketType = BaseConstants.LogoType,
                QueryString = string.Empty
            };
            
            var tcpData = new TCPData()
            {
                Query = dbQuery,
                TcpTypes = TcpSerializeTypes.DBQuery
            };

            if (!SendTCPData(tcpData))
            {
                Logger.Log.Warn("RequireLogo. Server is unavailabe!");
                return false;
            }

            Logger.Log.Debug("RequireLogo. Exit");
            return true;
        }

        /// <summary>
        /// Use for send language require
        /// </summary>
        /// <param name="languageCode">Language code string</param>
        /// <returns></returns>
        public bool RequireLanguage(string languageCode)
        {
            Logger.Log.Debug("RequireLanguage. Enter");

            var dbQuery = new DBQuery()
            {
                PacketType = BaseConstants.LanguageType,
                QueryString = languageCode
            };

            var tcpData = new TCPData()
            {
                Query = dbQuery,
                TcpTypes = TcpSerializeTypes.DBQuery
            };

            if (!SendTCPData(tcpData))
            {
                Logger.Log.Warn("RequireLanguage. Server is unavailabe!");
                return false;
            }

            Logger.Log.Debug("RequireLanguage. Exit");
            return true;
        }

        /// <summary>
        /// Use for send currency require
        /// </summary>
        /// <param name="currencyCode">Currency code string</param>
        /// <returns></returns>
        public bool RequireCurrency(string currencyCode)
        {
            Logger.Log.Debug("RequireCurrency. Enter");

            var dbQuery = new DBQuery()
            {
                PacketType = BaseConstants.CurrencyType,
                QueryString = currencyCode
            };

            var tcpData = new TCPData()
            {
                Query = dbQuery,
                TcpTypes = TcpSerializeTypes.DBQuery
            };

            if (!SendTCPData(tcpData))
            {
                Logger.Log.Warn("RequireCurrency. Server is unavailabe!");
                return false;
            }

            Logger.Log.Debug("RequireCurrency. Exit");
            return true;
        }

        /// <summary>
        /// Use for send Shares and Sales require
        /// </summary>
        /// <param name="languageCode">Language code string</param>
        /// <returns></returns>
        public bool RequireShares(string languageCode)
        {
            Logger.Log.Debug("RequireShares. Enter");
            
            var dbQuery = new DBQuery()
            {
                PacketType = BaseConstants.SharesSalesType,
                QueryString = languageCode
            };

            var tcpData = new TCPData()
            {
                Query = dbQuery,
                TcpTypes = TcpSerializeTypes.DBQuery
            };

            if (!SendTCPData(tcpData))
            {
                Logger.Log.Warn("RequireShares. Server is unavailabe!");
                return false;
            }
            
            Logger.Log.Debug("RequireShares. Exit");
            return true;
        }

        /// <summary>
        /// Use for send Product info require
        /// </summary>
        /// <param name="barCodeData">BarCode string</param>
        /// <param name="languageCode">Language code string</param>
        /// <param name="currencyCode">Currency code string</param>
        /// <returns></returns>
        public bool RequireProductInfo(string barCodeData, string languageCode, string currencyCode)
        {
            Logger.Log.Debug("RequireProductInfo. Enter");

            var dbQuery = new DBQuery()
            {
                PacketType = BaseConstants.ProductInfoType,
                QueryString = string.Format("{1}{0}{2}{0}{3}", BaseConstants.TypeSplitter[0],
                barCodeData, languageCode, currencyCode)
            };

            var tcpData = new TCPData()
            {
                Query = dbQuery,
                TcpTypes = TcpSerializeTypes.DBQuery
            };

            if (!SendTCPData(tcpData))
            {
                Logger.Log.Warn("RequireProductInfo. Server is unavailabe!");
                return false;
            }
            
            Logger.Log.Debug("RequireProductInfo. Exit");
            return true;
        }

        #endregion

        /// <summary>
        /// Use for send data to tcp server
        /// </summary>
        /// <param name="tcpData">TCP Data packet</param>
        /// <returns></returns>
        private bool SendTCPData(TCPData tcpData)
        {
            Logger.Log.Debug("SendTCPData. Enter");
            
            if (!_mainEntry.TcpService.Send<TCPData>(tcpData))
            {
                Logger.Log.WarnFormat("SendTCPData. TCPData: [{0}] - Wasn't sent to server",
                    tcpData.Query.PacketType);
                return false;
            }

            Logger.Log.Debug("SendTCPData. Exit");
            return true;
        }

        #endregion
    }
}