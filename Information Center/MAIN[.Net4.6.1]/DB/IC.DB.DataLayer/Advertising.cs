using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.DB.DataLayer
{
    /// <summary>
    /// Presents Advertising table entity
    /// 
    /// 2018/04/15 - Created, VTyagunov
    /// </summary>
    [Table("Advertising")]
    public class Advertising
    {
        /// <summary>Advertising ID</summary>
        [Key]
        public int AdvertisingID { get; set; }
        /// <summary>Status of the advertising accessibility</summary>
        public byte AccessStatus { get; set; }
        /// <summary>Image of the advertising</summary>
        public byte[] Image { get; set; }
    }
}