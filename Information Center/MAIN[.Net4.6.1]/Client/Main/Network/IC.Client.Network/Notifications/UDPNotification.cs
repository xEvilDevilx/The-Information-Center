using System;
using System.Net;
using System.Reflection;
using System.Text;

using IC.Client.DataLayer;
using IC.Client.Network.Interfaces;
using IC.SDK;
using IC.SDK.Base;
using IC.SDK.Base.Enums;
using IC.SDK.Helpers;
using IC.SDK.Interfaces;
using IC.SDK.Interfaces.Serialization;
using IC.SDK.Serialization;

namespace IC.Client.Network.Notifications
{
    /// <summary>
    /// Presents UDP Notification transfer
    /// 
    /// 2017/03/02 - Created, VTyagunov
    /// </summary>
    public class UDPNotification : INetworkNotification
    {
        #region Variables

        /// <summary>Timer presents period of send notification</summary>
        private ISimpleTimer _timer;
        /// <summary>IC Serialization tool</summary>
        private IBytesArraySerializer _serializer;
        /// <summary>Client MAC Address</summary>
        private string _macAddress;
        /// <summary>Client information</summary>
        private ClientInfo _clientInfo;
        /// <summary>Client information bytes array</summary>
        private byte[] _clientInfoBytes;
        /// <summary>UDP Data packet</summary>
        private UDPData _udpData;
        /// <summary>Group End point</summary>
        private IPEndPoint _groupEndPoint;
        /// <summary>Client Main Entry</summary>
        private IMainEntry _mainEntry;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="enpPoint">Group End Point</param>
        /// <param name="mainEntry">Client Main Entry</param>
        public UDPNotification(IPEndPoint enpPoint, IMainEntry mainEntry)
        {
            Logger.Log.Debug("UDPNotification. Ctr. Enter");

            if (enpPoint == null)
                throw new ArgumentNullException("enpPoint");

            if (mainEntry == null)
                throw new ArgumentNullException("mainEntry");

            _timer = new SimpleTimer();
            _serializer = new Serializer();
            _macAddress = Utils.GetMacAddress();
            _clientInfo = new ClientInfo()
            {
                AssemblyVersion = Assembly.GetCallingAssembly().GetName().Version,
                MACAddress = Encoding.Default.GetBytes(_macAddress),
                UID = MainEntry._uniqueClientLicenseKey
            };
            _clientInfoBytes = _serializer.SerializeToBytesArray(_clientInfo, UdpSerializeTypes.ClientInfo);
            _groupEndPoint = enpPoint;
            _udpData = new UDPData()
            {
                BytesArray = _clientInfoBytes,
                EndPoint = _groupEndPoint
            };
            _mainEntry = mainEntry;

            Logger.Log.Debug("UDPNotification. Ctr. Exit");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Start send notification in timer period
        /// </summary>
        /// <param name="sendTimePeriod">Send time period</param>
        public void StartSend(int sendTimePeriod)
        {
            Logger.Log.Debug("StartSend. Enter");

            Utils.StartSimpleThread(() => { StartSendAction(sendTimePeriod); });

            Logger.Log.Debug("StartSend. Exit");
        }

        /// <summary>
        /// Start send notification in timer period
        /// </summary>
        /// <param name="sendTimePeriod">Time period to send Action</param>
        private void StartSendAction(int sendTimePeriod)
        {
            Logger.Log.Debug("StartSendAction. Enter");

            try
            {
                byte _udpSendLimitForReset = 0;

                if (!_mainEntry.UdpService.Send<UDPData>(_udpData))
                    ReCreateUDPService();

                _timer.Start(sendTimePeriod, () =>
                {
                    if (!_mainEntry.UdpService.Send<UDPData>(_udpData))
                        ReCreateUDPService();

                    _udpSendLimitForReset++;
                    if (_udpSendLimitForReset >= 10)
                    {
                        ReCreateUDPService();
                        _udpSendLimitForReset = 0;
                    }
                });
            }
            catch (Exception ex)
            {
                Logger.Log.Error("StartSendAction", ex);
            }

            Logger.Log.Debug("StartSendAction. Exit");
        }

        /// <summary>
        /// Use for stop send notification
        /// </summary>
        public void StopSend()
        {
            Logger.Log.Debug("StopSend. Enter");

            _timer.Stop();

            Logger.Log.Debug("StopSend. Exit");
        }

        /// <summary>
        /// Use for recreating UDPClientService
        /// </summary>
        private void ReCreateUDPService()
        {
            Logger.Log.Debug("ReCreateUDPService. Enter");

            _mainEntry.UdpService.Stop();
            _mainEntry.UdpService = new UDPClientService(null);

            Logger.Log.Debug("ReCreateUDPService. Exit");
        }

        #endregion
    }
}