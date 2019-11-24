using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.DB.DataLayer
{
    /// <summary>
    /// Presents Config table entity
    /// 
    /// 2018/04/15 - Created, VTyagunov
    /// </summary>
    [Table("Config")]
    public class Config
    {
        /// <summary>Config ID</summary>
        [Key, Column(Order = 0)]
        public int ConfigID { get; set; }
        /// <summary>Store ID</summary>
        [Key, Column(Order = 1)]
        [MaxLength(5)]
        public string StoreID { get; set; }
        /// <summary>Value of the Config</summary>
        public string ConfigValue { get; set; }
    }
}