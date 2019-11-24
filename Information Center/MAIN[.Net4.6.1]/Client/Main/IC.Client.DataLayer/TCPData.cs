using IC.SDK.Base.Enums;

namespace IC.Client.DataLayer
{
    /// <summary>
    /// Presents TCP Data packet
    /// 
    /// 2017/01/27 - Created, VTyagunov
    /// </summary>
    public class TCPData
    {
        /// <summary>DB Query object</summary>
        public DBQuery Query { get; set; }
        /// <summary>Tcp Serialize Type</summary>
        public TcpSerializeTypes TcpTypes { get; set; }
    }
}