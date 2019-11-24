using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.DB.DataLayer
{
    /// <summary>
    /// Presents EventLog table entity
    /// 
    /// 2018/04/15 - Created, VTyagunov
    /// </summary>
    [Table("EventLog")]
    public class EventLog
    {
        /// <summary>Event ID</summary>
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventID { get; set; }
        /// <summary>Terminal ID</summary>
        [Key, Column(Order = 1)]
        [MaxLength(5)]
        public string TerminalID { get; set; }
        /// <summary>Data and Time of the Event</summary>
        public DateTime EventDataTime { get; set; }
        /// <summary>Type of the Event</summary>
        public byte EventType { get; set; }
        /// <summary>Source of the Event</summary>
        public string EventSource { get; set; }
        /// <summary>Details of the Event</summary>
        public string EventDetails { get; set; }
    }
}