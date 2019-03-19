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

    }
}

