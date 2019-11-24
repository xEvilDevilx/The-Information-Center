using System;
using System.IO;

using IC.Client.DataLayer;
using IC.Client.Network.Interfaces;
using IC.SDK;
using IC.SDK.Base;
using IC.SDK.Base.Enums;
using IC.SDK.Helpers;
using IC.SDK.Interfaces.Serialization;
using IC.SDK.Serialization;
using IC.SDK.Interfaces;

namespace IC.Client.Network.Notifications
{
    /// <summary>
    /// Presents UDP Notification transfer
    /// 
    /// 2017/03/02 - Created, VTyagunov
    /// </summary>
    public class TCPNotification : INetworkNotification
    {
        #region Variables

        /// <summary>Timer presents period of send notification with Client Status</summary>
        private ISimpleTimer _sendClientStatusTimer;
        /// <summary>Timer presents period of send notification with recreate services</summary>
        private ISimpleTimer _recreateTimer;
        /// <summary>Client Main Entry</summary>
        private IMainEntry _mainEntry;
        /// <summary>IC Stream Serialization tool</summary>
        private IStreamSerializer _streamSerializer;
        /// <summary>Client stream</summary>
        private Stream _clientStream;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clientStream">Client stream</param>
        /// <param name="mainEntry">Client Main Entry</param>
        public TCPNotification(Stream clientStream, IMainEntry mainEntry)
        {
            Logger.Log.Debug("TCPNotification. Ctr. Enter");

            if (clientStream == null)
                throw new ArgumentNullException("clientStream");

            if (mainEntry == null)
                throw new ArgumentNullException("mainEntry");

            _sendClientStatusTimer = new SimpleTimer();
            _recreateTimer = new SimpleTimer();
            _streamSerializer = new Serializer();
            _mainEntry = mainEntry;
            _clientStream = clientStream;

            Logger.Log.Debug("TCPNotification. Ctr. Exit");
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

            try
            {      
                Utils.StartSimpleThread(() => { SendClientStatusTimer(sendTimePeriod); });
                Utils.StartSimpleThread(() => { RecreateTimer(sendTimePeriod * 2); });

                Logger.Log.Debug("StartSend. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("StartSend.", ex);
            }
        }

        /// <summary>
        /// Use for send client status by timer
        /// </summary>
        /// <param name="sendTimePeriod">Time period to send</param>
        private void SendClientStatusTimer(int sendTimePeriod)
        {
            Logger.Log.Debug("SendClientStatusTimer. Enter");

            SendClientStatus();

            _sendClientStatusTimer.Start(sendTimePeriod, () =>
            {
                SendClientStatus();
            });

            Logger.Log.Debug("SendClientStatusTimer. Exit");
        }

        /// <summary>
        /// Use for start recreate timer, which analyze client connection status and 
        /// restart client connection if connection lost
        /// </summary>
        /// <param name="timePeriod">Time period to check client connection status</param>
        private void RecreateTimer(int timePeriod)
        {
            Logger.Log.Debug("RecreateTimer. Enter");

            _recreateTimer.Start(timePeriod, () =>
            {
                if (!_mainEntry.TcpService.IsConnected)
                {
                    StopSend();
                    _mainEntry.UdpNotification.StartSend(BaseConstants.ClientSendInterval);
                }
                _mainEntry.TcpService.IsConnected = false;
            });

            Logger.Log.Debug("RecreateTimer. Exit");
        }

        /// <summary>
        /// Use for send Client Status
        /// </summary>
        /// <returns></returns>
        private bool SendClientStatus()
        {
            Logger.Log.Debug("SendClientStatus. Enter");

            try
            {
                var clientStatus = new ClientStatus()
                {
                    isOnLine = true
                };
                if (!SendTCPData(clientStatus, TcpSerializeTypes.ClientStatus))
                {
                    StopSend();
                    _mainEntry.UdpNotification.StartSend(BaseConstants.ClientSendInterval);
                }
                else ConnectionStatus.Instance.IsConnected = true;

                Logger.Log.Debug("SendClientStatus. Exit");
                return ConnectionStatus.Instance.IsConnected;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("SendClientStatus", ex);
                return false;
            }
        }

        /// <summary>
        /// Use for send TCP Data packet
        /// </summary>
        /// <param name="obj">Packet object to send</param>
        /// <param name="tcpSerializeTypes">Packet type</param>
        private bool SendTCPData(object obj, TcpSerializeTypes tcpSerializeTypes)
        {
            Logger.Log.Debug("SendTCPData. Enter");
            
            try
            {
                _streamSerializer.Serialize(_clientStream, obj, tcpSerializeTypes);

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
        /// Use for stop send notification
        /// </summary>
        public void StopSend()
        {
            Logger.Log.Debug("StopSend. Enter");
            
            _sendClientStatusTimer.Stop();
            _recreateTimer.Stop();
            ConnectionStatus.Instance.IsConnected = false;

            Logger.Log.Debug("StopSend. Exit");
        }

        #endregion
    }
}