using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.DB.DataLayer
{
    /// <summary>
    /// Presents ProductLog table entity
    /// 
    /// 2018/04/15 - Created, VTyagunov
    /// </summary>
    [Table("ProductLog")]
    public class ProductLog
    {
        /// <summary>Product Log ID</summary>
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductLogID { get; set; }
        /// <summary>Product ID</summary>
        [Key, Column(Order = 1)]
        public int ProductID { get; set; }
        /// <summary>Date of the Product Scan</summary>
        public DateTime ScanDate { get; set; }
        /// <summary>Code of the Language</summary>
        [MaxLength(5)]
        public string LanguageCode { get; set; }
        /// <summary>Code of the Currency</summary>
        [MaxLength(5)]
        public string CurrencyCode { get; set; }
        /// <summary>Terminal ID</summary>
        [MaxLength(5)]
        public string TerminalID { get; set; }
    }
}