using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Database.Entities{

    [Table("student")]
    public class Student
    {
        [Column("student_id")]
        [Key]
        public long StudentId {get; set;}

        [Column("email_address")]
        public string Email {get; set;}

        [Column("student_count")]
        static public int StudentCount {get; set;}

    [Column("person_id")]
        public long PersonId { get; set; }
        public Person Person { get; set; }

    }
}

