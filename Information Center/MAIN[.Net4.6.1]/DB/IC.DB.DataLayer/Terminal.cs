using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.DB.DataLayer
{
    /// <summary>
    /// Presents Terminal table entity
    /// 
    /// 2018/04/15 - Created, VTyagunov
    /// </summary>
    [Table("Terminal")]
    public class Terminal
    {
        /// <summary>Terminal ID</summary>
        [Key, Column(Order = 0)]
        [MaxLength(5)]
        public string TerminalID { get; set; }
        /// <summary>Store ID</summary>
        [Key, Column(Order = 1)]
        [MaxLength(5)]
        public string StoreID { get; set; }
        /// <summary>Terminal Mac Address</summary>
        public string MacAddress { get; set; }
        /// <summary>Terminal IP Address</summary>
        [MaxLength(16)]
        public string IPAddress { get; set; }
        /// <summary>Status of the Product accessibility</summary>
        public byte OnlineStatus { get; set; }
        /// <summary>Terminal Unique ID</summary>
        public string TerminalUID { get; set; }
        /// <summary>Terminal Version</summary>
        public string TerminalVersion { get; set; }
    }
}