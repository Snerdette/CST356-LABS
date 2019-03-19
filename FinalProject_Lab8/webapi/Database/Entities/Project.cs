using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database.Entities{

    [Table("project")]
    public class Project
    {
        [Column("project_id")]
        [Key]
        public long ProjectId {get; set;}

        [Column("title")]
        public string Title {get; set;}

        [Column("type")]
        public string Type {get; set;}

        [Column("site")]
        public string Site {get; set;}

        [Column("start_date")]
        public string StartDate {get; set;}
        
        [Column("end_date")]
        public string EndDate {get; set;}

    [Column("event_id")]
        public long EventId { get; set; }
        public Event Event { get; set; }

    [Column("blog_id")]
        public long BlogId { get; set; }
        public Blog Blog { get; set; }

    }
    
}