using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using IC.Client.DataLayer;
using IC.Client.Network.Interfaces;
using IC.Client.Network.Notifications;
using IC.SDK;
using IC.SDK.Helpers;

namespace IC.Client.Network
{
    /// <summary>
    /// Implements UDP service work
    /// 
    /// 2017/03/02 - Created, VTyagunov
    /// </summary>
    public class UDPClientService : INetworkService
    {
        #region Properties

        /// <summary>Flag to show client connection status</summary>
        [Obsolete]
        public bool IsConnected { get; set; }

        #endregion

        #region Variables

        /// <summary>Client Main Entry</summary>
        private IMainEntry _mainEntry;
        /// <summary>Local IP Address for Bind</summary>
        private IPEndPoint _endPoint;
        /// <summary>Flag uses for signal to receive or not receive data from UDP</summary>
        private bool _isReceive;
        /// <summary>UDP client</summary>
        private UdpClient _udpClient;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainEntry">Client Main Entry</param>
        public UDPClientService(IMainEntry mainEntry)
        {
            Logger.Log.Debug("UDPClientService. Ctr. Enter");

            if (mainEntry == null)
                throw new ArgumentNullException("mainEntry");

            _mainEntry = mainEntry;

            Logger.Log.Debug("UDPClientService. Ctr. Exit");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for receive data packets from UDP
        /// </summary>
        /// <param name="endPoint">Client IP End Point for UDP work</param>
        public void Start(IPEndPoint endPoint)
        {
            Logger.Log.Debug("Start. Enter");

            if (endPoint == null)
            {
                var ipAddress = IPAddress.Parse(Utils.LocalIPAddress());
                _endPoint = new IPEndPoint(ipAddress, 44331);
            }
            else _endPoint = endPoint;

            Utils.StartSimpleThread(StartAction);

            Logger.Log.Debug("Start. Exit");
        }

        /// <summary>
        /// Use for start work with received UPD packets
        /// </summary>
        private void StartAction()
        {
            Logger.Log.Debug("StartAction. Enter");

            try
            {                
                _udpClient = new UdpClient();
                _udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, 
                    SocketOptionName.ExclusiveAddressUse, false);
                _udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, 
                    SocketOptionName.ReuseAddress, true);
                _udpClient.Client.Bind(_endPoint);
                _isReceive = true;

                var groupEndPoint = Utils.GetUDPEndPoint();
                _mainEntry.UdpNotification = new UDPNotification(groupEndPoint, _mainEntry);
                _mainEntry.Transfer.StartUDPNotifyThread();

                while (_isReceive)
                {
                    IPEndPoint remoteIp = null;
                    var data = _udpClient.Receive(ref remoteIp);
                    _mainEntry.Transfer.UDPProcess(data);
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("StartAction", ex);
            }
            finally
            {
                Logger.Log.Debug("StartAction. Exit");
                Stop();
            }
        }

        /// <summary>
        /// Use for send packet to server
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <param name="t">T object to send</param>
        /// <returns>Shows status of packet send(true if success)</returns>
        public bool Send<T>(T t)
        {
            try
            {
                Logger.Log.Debug("Send. Enter");

                var udpData = t as UDPData;
                _udpClient.Send(udpData.BytesArray, udpData.BytesArray.Length, udpData.EndPoint);

                Logger.Log.Debug("Send. Exit");
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Send.", ex);
                return false;
            }
        }

        /// <summary>
        /// Use for stop receive data packets from UDP
        /// </summary>
        public void Stop()
        {
            Logger.Log.Debug("Stop. Enter");

            try
            {
                _udpClient.Client.Shutdown(SocketShutdown.Both);
                _udpClient.Client.Close();
                _isReceive = false;

                Logger.Log.Debug("Stop. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Stop", ex);
            }
        }
        
        #endregion
    }
}