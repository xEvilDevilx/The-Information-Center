using System.Net;

namespace IC.Client.DataLayer
{
    /// <summary>
    /// Presents UDP Data packet
    /// 
    /// 2016/01/22 - created VTyagunov
    /// </summary>
    public class UDPData
    {
        /// <summary>Packet bytes array</summary>
        public byte[] BytesArray { get; set; }
        /// <summary>End point of receiver</summary>
        public IPEndPoint EndPoint { get; set; }
    }
}