using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.DB.DataLayer
{
    /// <summary>
    /// Presents Store table entity
    /// 
    /// 2018/04/15 - Created, VTyagunov
    /// </summary>
    [Table("Store")]
    public class Store
    {
        /// <summary>Store ID</summary>
        [Key]
        [MaxLength(5)]
        public string StoreID { get; set; }
        /// <summary>Caption ID</summary>
        public int CaptionID { get; set; }
        /// <summary>Image of the Store</summary>
        public byte[] Image { get; set; }
    }
}