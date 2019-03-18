using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database.Entities{

    [Table("person")]
    public class Person
    {
        [Column("person_id")]
        [Key]
        public long PersonId {get; set;}

        [Column("first_name")]
        public string First_Name {get; set;}

        [Column("middle_name")]
        public string Middle_Name {get; set;}

        [Column("last_name")]
        public string Last_Name {get; set;}

        public Student Student { get; set; }
    }
}