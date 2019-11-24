using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.DB.DataLayer
{
    /// <summary>
    /// Presents ProductPrice table entity
    /// 
    /// 2018/04/15 - Created, VTyagunov
    /// </summary>
    [Table("ProductPrice")]
    public class ProductPrice
    {
        /// <summary>Store ID</summary>
        [Key, Column(Order = 0)]
        [MaxLength(5)]
        public string StoreID { get; set; }
        /// <summary>Product ID</summary>
        [Key, Column(Order = 1)]
        public int ProductID { get; set; }
        /// <summary>Date and Time of the Begin last Product Price</summary>
        [Key, Column(Order = 2)]
        public DateTime DateBegin { get; set; }
        /// <summary>Date and Time of the End last Product Price</summary>
        public DateTime DateEnd { get; set; }
        /// <summary>Value of the Price</summary>
        [DataType("decimal(20,10)")]
        public decimal PriceValue { get; set; }
    }
}