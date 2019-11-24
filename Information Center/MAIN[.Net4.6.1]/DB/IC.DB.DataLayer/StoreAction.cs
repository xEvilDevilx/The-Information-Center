using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.DB.DataLayer
{
    /// <summary>
    /// Presents StoreAction table entity
    /// 
    /// 2018/04/15 - Created, VTyagunov
    /// </summary>
    [Table("StoreAction")]
    public class StoreAction
    {
        /// <summary>Store ID</summary>
        [Key, Column(Order = 0)]
        [MaxLength(5)]
        public string StoreID { get; set; }
        /// <summary>Retail Action ID</summary>
        [Key, Column(Order = 1)]
        public int RetailActionID { get; set; }
    }
}