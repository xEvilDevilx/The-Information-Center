namespace IC.Client.DataLayer
{
    /// <summary>
    /// Presents database query data
    /// 
    /// 2016/12/11 - Created, VTyagunov
    /// </summary>
    public class DBQuery
    {
        /// <summary>Packet type</summary>
        public byte PacketType { get; set; }
        /// <summary>Query string</summary>
        public string QueryString { get; set; }
    }
}