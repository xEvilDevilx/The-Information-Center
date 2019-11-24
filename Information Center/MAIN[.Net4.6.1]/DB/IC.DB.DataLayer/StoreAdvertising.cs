using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.DB.DataLayer
{
    /// <summary>
    /// Presents StoreAdvertising table entity
    /// 
    /// 2018/04/15 - Created, VTyagunov
    /// </summary>
    [Table("StoreAdvertising")]
    public class StoreAdvertising
    {
        /// <summary>Store ID</summary>
        [Key, Column(Order = 0)]
        [MaxLength(5)]
        public string StoreID { get; set; }
        /// <summary>Terminal ID</summary>
        [Key, Column(Order = 1)]
        [MaxLength(5)]
        public string TerminalID { get; set; }
        /// <summary>Advertising ID</summary>
        [Key, Column(Order = 2)]
        public int AdvertisingID { get; set; }
    }
}