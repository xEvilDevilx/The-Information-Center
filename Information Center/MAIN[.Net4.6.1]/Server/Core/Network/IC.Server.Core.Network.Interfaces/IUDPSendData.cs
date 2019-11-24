using System.Net;
using System.Net.Sockets;

namespace IC.Server.Core.Network.Interfaces
{
    /// <summary>
    /// Presents send bytes array to UDP socket
    /// 
    /// 2016/12/23 - Created, VTyagunov
    /// </summary>
    public interface IUDPSendData
    {
        /// <summary>
        /// Do send data to remote end point
        /// </summary>
        /// <param name="remoteEndPoint">Client ip end point</param>
        /// <param name="bytesArray">Data bytes array</param>
        /// <param name="udpClient">UDP Client</param>
        void SendData(IPEndPoint remoteEndPoint, byte[] bytesArray, UdpClient udpClient);
    }
}