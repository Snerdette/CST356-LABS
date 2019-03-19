using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Database.Entities{

    [Table("event")]
    public class Event
    {
        [Column("event_id")]
        [Key]
        public long EventId {get; set;}

        [Column("name")]
        public string Name {get; set;}

        [Column("location")]
        public string Location {get; set;}

        [Column("start_time")]
        public string StartTime {get; set;}

        [Column("end_time")]
        public string EndTime {get; set;}

    }

}

