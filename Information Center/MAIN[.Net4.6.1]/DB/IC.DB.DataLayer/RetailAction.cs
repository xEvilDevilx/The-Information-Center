using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.DB.DataLayer
{
    /// <summary>
    /// Presents RetailAction table entity
    /// 
    /// 2018/04/15 - Created, VTyagunov
    /// </summary>
    [Table("RetailAction")]
    public class RetailAction
    {
        /// <summary>Retail Action ID</summary>
        [Key]
        public int RetailActionID { get; set; }
        /// <summary>Date and Time of the Begin last Retail Action</summary>
        public DateTime DateBegin { get; set; }
        /// <summary>Date and Time of the End last Retail Action</summary>
        public DateTime DateEnd { get; set; }
        /// <summary>Status of the Product accessibility</summary>
        public byte AccessStatus { get; set; }
        /// <summary>Caption ID</summary>
        public int CaptionID { get; set; }
        /// <summary>Description ID</summary>
        public int DescriptionID { get; set; }
    }
}