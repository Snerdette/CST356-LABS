using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Database.Entities;
using System;

namespace Database
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)         
        {         
        }
        
        public DbSet<Student> Student { get; set; }
        public DbSet<Person> Person { get; set; }
         
       public DbSet<Student> getStudent { get; set; } 

        public DbSet<Student> getStudentById { get; set; }

        public DbSet<Student> getStudentCount { get; set; }

    }
}