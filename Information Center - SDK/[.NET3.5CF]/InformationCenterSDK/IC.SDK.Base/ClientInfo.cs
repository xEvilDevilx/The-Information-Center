using System;

namespace IC.SDK.Base
{
    /// <summary>
    /// Store client info
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    public class ClientInfo
    {
        /// <summary>Client Unique License-key</summary>
        public string UID { get; set; }
        /// <summary>MAC-address of client</summary>
        public byte[] MACAddress { get; set; }
        /// <summary>Current client version/summary>
        public Version AssemblyVersion { get; set; }
    }
}