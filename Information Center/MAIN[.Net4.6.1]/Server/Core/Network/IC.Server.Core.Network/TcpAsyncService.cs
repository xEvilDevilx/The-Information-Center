using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

using IC.SDK;
using IC.Server.Core.Base;
using IC.Server.Core.ClientManager.Interfaces;
using IC.Server.Core.Interfaces;

namespace IC.Server.Core.Network
{
    /// <summary>
    /// Implements TCP work
    /// 
    /// 2016/12/11 - Created, VTyagunov
    /// </summary>
    public class TcpAsyncService : IAsyncService
    {        
        #region Variables

        /// <summary>Server port</summary>
        private readonly int _port;
        /// <summary>TCP Listener</summary>
        private readonly TcpListener _listener;
        /// <summary>Use for work or stop listen cycle</summary>
        private bool _isListen;        
        /// <summary>Do work with clients</summary>
        private readonly IClientWorker _clientWorker;

        #endregion

        #region Properties

        /// <summary>Client collection</summary>
        public ISimpleCollection<ClientData> Clients { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="port">Server port</param>
        /// <param name="clientWorker">Client Worker</param>
        /// <param name="сlients">Client collection</param>
        public TcpAsyncService(int port, IClientWorker clientWorker, ISimpleCollection<ClientData> сlients)
        {
            Logger.Log.Debug("TcpAsyncService. Ctr. Enter");

            if (сlients == null)
                throw new ArgumentNullException(
                    string.Format("TcpAsyncService. Parameter {0} is empty", сlients), "сlientManager");

            _port = port;
            Clients = сlients;
            _clientWorker = clientWorker;            
            _listener = new TcpListener(IPAddress.Any, _port);
            _listener.Server.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false);
            
            Logger.Log.Debug("TcpAsyncService. Ctr. Exit");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for async start Tcp listener
        /// </summary>
        public async void RunAsync()
        {
            Logger.Log.Debug("RunAsync. Enter");

            _listener.Start();
            _isListen = true;

            while (_isListen)
            {
                try
                {
                    var tcpClient = await _listener.AcceptTcpClientAsync();
                    await Task.Factory.StartNew(() =>
                    {
                        _clientWorker.TcpProcess(tcpClient, Clients);
                    });
                }
                catch (Exception ex)
                {
                    Logger.Log.Error("RunAsync.", ex);
                }
            }

            Logger.Log.Debug("RunAsync. Exit");
        }

        /// <summary>
        /// Use for stop Tcp listener
        /// </summary>
        public void Stop()
        {
            Logger.Log.Debug("Stop. Enter");

            _isListen = false;
            _listener.Stop();

            Logger.Log.Debug("Stop. Exit");
        }

        #endregion
    }
}