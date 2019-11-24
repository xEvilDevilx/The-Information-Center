using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

using IC.Client.DataLayer;
using IC.Client.Network.Interfaces;
using IC.LicenseManager.CryptoService;
using IC.LicenseManager.Interfaces;
using IC.SDK;
using IC.SDK.Base.Enums;
using IC.SDK.Base.Constants;
using IC.SDK.Helpers;
using IC.SDK.Interfaces;
using IC.SDK.Interfaces.Serialization;
using IC.SDK.Serialization;

namespace IC.Client.Network.Notifications
{
    /// <summary>
    /// Implements License verify functionality
    /// 
    /// 2017/03/02 - Created, VTyagunov
    /// </summary>
    public class TCPLicenseVerify : INetworkNotification
    {
        #region Variables

        /// <summary>TimeOut timer</summary>
        private ISimpleTimer _timeOutTimer;
        /// <summary>Main Client Entry</summary>
        private IMainEntry _mainEntry;
        /// <summary>IC Serialization tool</summary>
        private IStreamSerializer _serializer;
        /// <summary>Client stream</summary>
        private Stream _clientStream;
        /// <summary>License creator tool</summary>
        private ILicenseCreator _licenseCreator;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clientStream">Client stream</param>
        /// <param name="mainEntry">Client Main Entry</param>
        public TCPLicenseVerify(Stream clientStream, IMainEntry mainEntry)
        {
            Logger.Log.Debug("TCPLicenseVerify. Ctr. Enter");

            if (clientStream == null)
                throw new ArgumentNullException("clientStream");

            if (mainEntry == null)
                throw new ArgumentNullException("mainEntry");

            _timeOutTimer = new SimpleTimer();
            _serializer = new Serializer();
            _licenseCreator = new LicenseCreator();
            _mainEntry = mainEntry;
            _clientStream = clientStream;

            Logger.Log.Debug("TCPLicenseVerify. Ctr. Exit");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Start send license data in timer period
        /// </summary>
        /// <param name="timeOut">TimeOut to stop checkLicense and start udp send</param>
        public void StartSend(int timeOut)
        {
            Logger.Log.Debug("StartSend. Enter");

            try
            {
                SendLicenseData();
                Utils.StartSimpleThread(() => { StopVerifyByTimeOut(timeOut); });

                Logger.Log.Debug("StartSend. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("StartSend.", ex);
            }
        }

        /// <summary>
        /// Use for stop verify by timeOut
        /// </summary>
        /// <param name="timeOut">TimeOut value to stop verify</param>
        private void StopVerifyByTimeOut(int timeOut)
        {
            Logger.Log.Debug("StopVerifyByTimeOut. Enter");

            _timeOutTimer.Start(timeOut, () => StopVerify());

            Logger.Log.Debug("StopVerifyByTimeOut. Exit");
        }

        /// <summary>
        /// Use for send License Data
        /// </summary>
        private void SendLicenseData()
        {
            Logger.Log.Debug("SendLicenseData. Enter");

            try
            {
                var macAddress = Utils.GetMacAddress();
                var version = AssemblyWorker.Instance.Version;
                var uid = MainEntry._uniqueClientLicenseKey;
                var password = GetPasswordValueFromConfig();

                var licenseKeySignature =
                    _licenseCreator.CreateLicenseKeySignature(macAddress, version, uid, password);
                var licenseData = new LicenseData()
                {
                    LicenseDataArray = licenseKeySignature
                };

                if (!SendTCPData(licenseData, TcpSerializeTypes.LicenseData))
                    StopVerify();

                Logger.Log.Debug("SendLicenseData. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("SendLicenseData", ex);
            }
        }

        /// <summary>
        /// Use for stop verify
        /// </summary>
        private void StopVerify()
        {
            Logger.Log.Debug("StopVerify. Enter");

            StopSend();
            _mainEntry.TcpService.IsConnected = false;
            ConnectionStatus.Instance.IsConnected = false;
            _mainEntry.UdpNotification.StartSend(BaseConstants.ClientSendInterval);

            Logger.Log.Debug("StopVerify. Exit");
        }

        /// <summary>
        /// Use for get Password value from Config file
        /// </summary>
        /// <returns>Password string value</returns>
        private string GetPasswordValueFromConfig()
        {
            Logger.Log.Debug("GetPasswordValueFromConfig. Enter");

            try
            {
                var dirName = string.Format("{0}\\{1}", Utils.GetCurrentDirectory(),
                    BaseConstants.ClientConfigXMLName);
                var xml = XDocument.Load(dirName);
                var tagValue = xml.Descendants(BaseConstants.ConfigPasswordValue).First();

                Logger.Log.Debug("GetPasswordValueFromConfig. Exit");

                return tagValue.Value;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetPasswordValueFromConfig. ", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for send TCP Data
        /// </summary>
        /// <param name="obj">Packet to send</param>
        /// <param name="tcpSerializeTypes">Tcp packet serialize type</param>
        private bool SendTCPData(object obj, TcpSerializeTypes tcpSerializeTypes)
        {
            Logger.Log.Debug("SendTCPData. Enter");

            try
            {
                _serializer.Serialize(_clientStream, obj, tcpSerializeTypes);

                Logger.Log.Debug("SendTCPData. Exit");
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("SendTCPData.", ex);
                return false;
            }
        }

        /// <summary>
        /// Use for stop timer
        /// </summary>
        public void StopSend()
        {
            Logger.Log.Debug("StopSend. Enter");

            _timeOutTimer.Stop();

            Logger.Log.Debug("StopSend. Exit");
        }

        #endregion
    }
}