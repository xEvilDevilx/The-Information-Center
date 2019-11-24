using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using IC.Client.DataLayer;
using IC.Client.Network.Interfaces;
using IC.Client.Network.Notifications;
using IC.SDK;
using IC.SDK.Base;
using IC.SDK.Helpers;
using IC.SDK.Interfaces.Serialization;
using IC.SDK.Serialization;

namespace IC.Client.Network
{
    /// <summary>
    /// Implements work with TCP service
    /// 
    /// 2017/03/02 - Created, VTyagunov
    /// </summary>
    public class TCPClientService : INetworkService
    {
        #region Properties

        /// <summary>Flag to show client connection status</summary>
        public bool IsConnected { get; set; }

        #endregion

        #region Variables

        /// <summary>Client Main Entry</summary>
        private IMainEntry _mainEntry;
        /// <summary>Server End Point</summary>
        private IPEndPoint _endPoint;
        /// <summary>Flag shows receive or not receive data packets from TCP</summary>
        private bool _isReceive;
        /// <summary>Tcp client</summary>
        private TcpClient _tcpClient;
        /// <summary>IC Stream Serialization tool</summary>
        private IStreamSerializer _streamSerializer;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainEntry">Client Main Entry</param>
        public TCPClientService(IMainEntry mainEntry)
        {
            Logger.Log.Debug("TCPClientService. Ctr. Enter");

            if (mainEntry == null)
                throw new ArgumentNullException("mainEntry");
            
            _isReceive = true;
            _mainEntry = mainEntry;
            _streamSerializer = new Serializer();

            Logger.Log.Debug("TCPClientService. Ctr. Exit");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for Start connection to Server
        /// </summary>
        /// <param name="endPoint">Server IP End Point</param>
        public void Start(IPEndPoint endPoint)
        {
            Logger.Log.Debug("Start. Enter");

            if (endPoint == null)
                _endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), BaseConstants.TcpServerPort);
            else _endPoint = endPoint;

            Utils.StartSimpleThread(StartAction);

            Logger.Log.Debug("Start. Exit");
        }

        /// <summary>
        /// Use for start work with receive pacets from server
        /// </summary>
        private void StartAction()
        {
            Logger.Log.Debug("StartAction. Enter");
            
            try
            {
                _tcpClient = new TcpClient(_endPoint.Address.ToString(), _endPoint.Port);
                var stream = _tcpClient.GetStream();
                _mainEntry.TcpNotification = new TCPNotification(stream, _mainEntry);
                _mainEntry.TcpLicenseVerify = new TCPLicenseVerify(stream, _mainEntry);
                _mainEntry.Transfer.StartTCPLicenseVerifyThread();

                while (_isReceive)
                {
                    if (stream.DataAvailable)
                    {
                        var obj = _streamSerializer.Deserialize(stream,
                             BaseConstants.ClientDataLayerNamespaceName, BaseConstants.ClientDataLayerLibName);
                        _mainEntry.Transfer.TCPProcess(obj);
                    }
                    Thread.Sleep(100);
                }

                Logger.Log.Debug("StartAction. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("StartAction.", ex);
            }            
        }

        /// <summary>
        /// Use for send T object to server
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <param name="t">T object to send</param>
        /// <returns>Shows status of send packet(true if success)</returns>
        public bool Send<T>(T t)
        {
            Logger.Log.Debug("Send. Enter");
            
            try
            {
                var tcpData = t as TCPData;
                var stream = _tcpClient.GetStream();
                _streamSerializer.Serialize(stream, tcpData.Query, tcpData.TcpTypes);

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
        /// Use for a disconnect from server
        /// </summary>
        public void Stop()
        {
            Logger.Log.Debug("Stop. Enter");

            _isReceive = false;
            if (_tcpClient != null)
                _tcpClient.Close();

            Logger.Log.Debug("Stop. Exit");
        }

        #endregion
    }
}