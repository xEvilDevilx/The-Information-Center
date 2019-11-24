using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.DB.DataLayer
{
    /// <summary>
    /// Presents TerminalCurrency table entity
    /// 
    /// 2018/04/15 - Created, VTyagunov
    /// </summary>
    [Table("TerminalCurrency")]
    public class TerminalCurrency
    {
        /// <summary>Terminal ID</summary>
        [Key, Column(Order = 0)]
        [MaxLength(5)]
        public string TerminalID { get; set; }
        /// <summary>Store ID</summary>
        [Key, Column(Order = 1)]
        [MaxLength(5)]
        public string StoreID { get; set; }
        /// <summary>Code of the Currency</summary>
        [Key, Column(Order = 2)]
        [MaxLength(5)]
        public string CurrencyCode { get; set; }
    }
}