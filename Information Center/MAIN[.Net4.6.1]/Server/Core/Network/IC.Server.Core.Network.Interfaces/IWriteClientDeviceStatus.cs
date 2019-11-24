using System.Net;

namespace IC.Server.Core.Network.Interfaces
{
    /// <summary>
    /// Presents write client device status to db interface
    /// 
    /// 2016/12/23 - Created, VTyagunov
    /// </summary>
    public interface IWriteClientDeviceStatus
    {
        /// <summary>
        /// Use for write client device status to db
        /// </summary>
        /// <param name="ipAddress">Client IP-Address</param>
        /// <param name="status">Client device status for write</param>
        void WriteClientDeviceStatus(IPAddress ipAddress, byte status);
    }
}