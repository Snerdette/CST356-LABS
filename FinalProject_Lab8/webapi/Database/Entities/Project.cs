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

    }
    
}