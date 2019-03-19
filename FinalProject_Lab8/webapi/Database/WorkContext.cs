using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Database.Entities;
using System;

namespace Database
{
    public class WorkContext : DbContext
    {
        public WorkContext(DbContextOptions<WorkContext> options) : base(options)         
        {         
        }
        
        public DbSet<Project> Project { get; set; }

        public DbSet<Event> Event { get; set; }

        public DbSet<Blog> Blog { get; set; }
         



    }
}