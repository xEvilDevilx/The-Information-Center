using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.DB.DataLayer
{
    /// <summary>
    /// Presents Version table entity
    /// 
    /// 2018/04/15 - Created, VTyagunov
    /// </summary>
    [Table("Version")]
    public class Version
    {
        /// <summary>Key of the Version</summary>
        [Key]
        [MaxLength(8)]
        public string Key { get; set; }
        /// <summary>Value of the Version</summary>
        [MaxLength(10)]
        public string Value { get; set; }
    }
}