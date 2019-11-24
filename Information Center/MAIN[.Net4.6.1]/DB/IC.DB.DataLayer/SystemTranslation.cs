using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.DB.DataLayer
{
    /// <summary>
    /// Presents SystemTranslation table entity
    /// 
    /// 2018/04/15 - Created, VTyagunov
    /// </summary>
    [Table("SystemTranslation")]
    public class SystemTranslation
    {
        /// <summary>Translation ID</summary>
        [Key, Column(Order = 0)]
        public int TranslationID { get; set; }
        /// <summary>Code of the Language</summary>
        [Key, Column(Order = 1)]
        [MaxLength(5)]
        public string LanguageCode { get; set; }
        /// <summary>Value of the Translation</summary>
        public string TranslationValue { get; set; }
    }
}