using System.Net;

namespace IC.Client.Network.Interfaces
{
    /// <summary>
    /// Presents network service work
    /// 
    /// 2017/03/02 - Created, VTyagunov
    /// </summary>
    public interface INetworkService
    {
        /// <summary>Flag to show client connection status</summary>
        bool IsConnected { get; set; }

        /// <summary>
        /// Use for receive data packets
        /// </summary>
        /// <param name="endPoint"></param>
        void Start(IPEndPoint endPoint);

        /// <summary>
        /// Use for send data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Send<T>(T t);

        /// <summary>
        /// Use for stop receive data packets
        /// </summary>
        void Stop();
    }
}