using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.DB.DataLayer
{
    /// <summary>
    /// Presents CurrencyRate table entity
    /// 
    /// 2018/04/15 - Created, VTyagunov
    /// </summary>
    [Table("CurrencyRate")]
    public class CurrencyRate
    {
        /// <summary>Store ID</summary>
        [Key, Column(Order = 0)]
        [MaxLength(5)]
        public string StoreID { get; set; }
        /// <summary>Code of the Currency</summary>
        [Key, Column(Order = 1)]
        [MaxLength(5)]
        public string CurrencyCode { get; set; }
        /// <summary>Date of the Begin last currency rate</summary>
        public DateTime DateBegin { get; set; }
        /// <summary>Value of the Rate</summary>
        [DataType("decimal(20,10)")]
        public decimal RateValue { get; set; }
    }
}