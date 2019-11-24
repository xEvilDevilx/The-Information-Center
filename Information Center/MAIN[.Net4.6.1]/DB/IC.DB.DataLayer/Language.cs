using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.DB.DataLayer
{
    /// <summary>
    /// Presents Language table entity
    /// 
    /// 2018/04/15 - Created, VTyagunov
    /// </summary>
    [Table("Language")]
    public class Language
    {
        /// <summary>Code of the Language</summary>
        [Key]
        [MaxLength(5)]
        public string LanguageCode { get; set; }
        /// <summary>Caption ID</summary>
        public int CaptionID { get; set; }
        /// <summary>Image of the Language</summary>
        public byte[] Image { get; set; }
    }
}