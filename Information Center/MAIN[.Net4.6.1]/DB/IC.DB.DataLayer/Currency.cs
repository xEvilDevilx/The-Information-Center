using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.DB.DataLayer
{
    /// <summary>
    /// Presents Currency table entity
    /// 
    /// 2018/04/15 - Created, VTyagunov
    /// </summary>
    [Table("Currency")]
    public class Currency
    {
        /// <summary>Code of the Currency</summary>
        [Key]
        [MaxLength(5)]
        public string CurrencyCode { get; set; }
        /// <summary>Caption ID</summary>
        public int CaptionID { get; set; }
        /// <summary>Image of the Currency</summary>
        public byte[] Image { get; set; }
    }
}