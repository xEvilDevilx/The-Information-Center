using System.Net;
using System.Net.Sockets;

using IC.Server.Core.Base;
using IC.Server.Core.Interfaces;

namespace IC.Server.Core.ClientManager.Interfaces
{
    /// <summary>
    /// Presents work with clients
    /// 
    /// 2016/12/22 - Created, VTyagunov
    /// </summary>
    public interface IClientWorker
    {
        /// <summary>
        /// Does work with received bytes array
        /// </summary>
        /// <param name="bytesArray">Received bytes array</param>
        /// <param name="remoteEndPoint">Client IPEndPoint</param>
        /// <param name="udpClient">UDP Client</param>
        /// <returns></returns>
        void UdpProcess(byte[] bytesArray, IPEndPoint remoteEndPoint, UdpClient udpClient);

        /// <summary>
        /// Does work with TcpClient stream
        /// </summary>
        /// <param name="tcpClient">Connected client</param>
        /// <param name="clients">Client collection</param>
        /// <returns></returns>
        void TcpProcess(TcpClient tcpClient, ISimpleCollection<ClientData> clients);

        /// <summary>
        /// Use for start check client connection status
        /// </summary>
        /// <param name="clientData">Client data</param>
        /// <param name="clients">Client collection</param>
        void StartCheckClientConnectionStatus(ClientData clientData, ISimpleCollection<ClientData> clients);

        /// <summary>
        /// Use for start check client stream for available income data
        /// </summary>
        /// <param name="clientData">Client data</param>
        void StartCheckClientStream(ClientData clientData);
    }
}