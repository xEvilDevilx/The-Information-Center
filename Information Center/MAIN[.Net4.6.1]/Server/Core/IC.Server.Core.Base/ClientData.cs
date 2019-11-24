using System;
using System.Net.Sockets;

namespace IC.Server.Core.Base
{
    /// <summary>
    /// Use for store connected client information
    /// 
    /// 2016/12/11 - created VTyagunov
    /// </summary>
    public class ClientData
    {
        /// <summary>Tcp client connection</summary>
        public TcpClient TcpClientConnection { get; set; }
        /// <summary>Flag shows OnLine Status of Client</summary>
        public bool IsOnLine { get; set; }
        /// <summary>Client MAC Address</summary>
        public string MACAddress { get; set; }
        /// <summary>Client Version</summary>
        public Version Version { get; set; }
        /// <summary>Client Unique ID</summary>
        public string ClientUID { get; set; }
    }
}