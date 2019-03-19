using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Database.Entities{

    [Table("blog")]
    public class Blog
    {
        [Column("blog_id")]
        [Key]
        public long BlogId {get; set;}

        [Column("heading")]
        public string Heading {get; set;}

        [Column("body")]
        public string Body {get; set;}

        [Column("date")]
        public string Date {get; set;}

        [Column("blog_count")]
        static public int BlogCount {get; set;}

    [Column("project_id")]
        public long ProjectId { get; set; }
        public Project Project { get; set; }

    [Column("event_id")]
        public long EventId { get; set; }
        public Event Event { get; set; }

    }
}

