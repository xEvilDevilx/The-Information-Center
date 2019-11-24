using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

using IC.SDK;
using IC.Server.Core.ClientManager.Interfaces;
using IC.Server.Core.Interfaces;

namespace IC.Server.Core.Network
{
    /// <summary>
    /// Implements UDP work
    /// 
    /// 2016/12/23 - Created, VTyagunov
    /// </summary>
    public class UdpAsyncService : IAsyncService
    {
        #region Variables

        /// <summary>Server port</summary>
        private readonly int _port;
        /// <summary>Use for work or stop listen cycle</summary>
        private bool _isReceive;        
        /// <summary>UDP client</summary>
        private UdpClient _udpClient;
        /// <summary>Do work with clients</summary>
        private readonly IClientWorker _clientWorker;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="port">Server port</param>
        /// <param name="clientWorker">Client Worker</param>
        public UdpAsyncService(int port, IClientWorker clientWorker)
        {
            Logger.Log.Debug("UdpAsyncService. Ctr. Enter");     
                   
            _port = port;
            _clientWorker = clientWorker;

            Logger.Log.Debug("UdpAsyncService. Ctr. Exit");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for async run of UDP listener
        /// </summary>
        public async void RunAsync()
        {
            Logger.Log.Debug("RunAsync. Enter");

            _isReceive = true;
            _udpClient = new UdpClient(_port)
            {
                EnableBroadcast = true
            };           
            
            try
            {
                while (_isReceive)
                {
                    IPEndPoint remoteEndPoint = null;
                    var receivedData = await _udpClient.ReceiveAsync();
                    remoteEndPoint = new IPEndPoint(receivedData.RemoteEndPoint.Address, 
                        receivedData.RemoteEndPoint.Port);
                    await Task.Factory.StartNew(() =>
                    {
                        _clientWorker.UdpProcess(receivedData.Buffer, remoteEndPoint, _udpClient);
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("RunAsync. ", ex);
            }
            finally
            {
                _udpClient.Close();
            }

            Logger.Log.Debug("RunAsync. Exit");
        }

        /// <summary>
        /// Use for stop receiver
        /// </summary>
        public void Stop()
        {
            Logger.Log.Debug("Stop. Enter");

            _isReceive = false;

            Logger.Log.Debug("Stop. Exit");
        }
        
        #endregion
    }
}