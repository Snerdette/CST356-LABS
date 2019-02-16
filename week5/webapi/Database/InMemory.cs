using System.Collections.Generic;

namespace Database
{
    public static class InMemory
    {
        public static List<Student> students = new List<Student> {
            new Student {
                Id = 1,
                fName = "Robin",
                lName = "Williams",
                email = "dobin.williams@oit.edu",
                enrolled = true
            },
            new Student {
                Id = 2,
                fName = "Dane",
                lName = "Cook",
                email = "dane.cook@oit.edu",
                enrolled = true
            },
            new Student {
                Id = 3,
                fName = "John",
                lName = "Mulaney",
                email = "john.mulane@oit.edu",
                enrolled = true
            }
        };

         public static List<Person> persons = new List<Person> {
            new Person {
                Id = 1,
                fName = "Robin",
                lName = "Williams",
                email = "dobin.williams@oit.edu",
                enrolled = true
            },
            new Person {
                Id = 2,
                fName = "Dane",
                lName = "Cook",
                email = "dane.cook@oit.edu",
                enrolled = true
            },
            new Person {
                Id = 3,
                fName = "John",
                lName = "Mulaney",
                email = "john.mulane@oit.edu",
                enrolled = true
            }
        };
    }
}