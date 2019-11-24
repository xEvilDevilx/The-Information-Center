using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.DB.DataLayer
{
    /// <summary>
    /// Presents Product table entity
    /// 
    /// 2018/04/15 - Created, VTyagunov
    /// </summary>
    [Table("Product")]
    public class Product
    {
        /// <summary>Product ID</summary>
        [Key, Column(Order = 0)]
        public int ProductID { get; set; }
        /// <summary>Value of the Barcode</summary>
        [Key, Column(Order = 1)]
        [MaxLength(20)]
        public string BarcodeValue { get; set; }
        /// <summary>Status of the Product accessibility</summary>
        public byte AccessStatus { get; set; }
        /// <summary>Article of the Product</summary>
        public string Article { get; set; }
        /// <summary>Caption ID</summary>
        public int CaptionID { get; set; }
        /// <summary>Description ID</summary>
        public int DescriptionID { get; set; }
        /// <summary>Image of the Product</summary>
        public byte[] Image { get; set; }
    }
}