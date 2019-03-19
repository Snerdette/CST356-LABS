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
        
        //public DbSet<Event> Event { get; set; }
         
        public DbSet<Project> getProject { get; set; } 

        public DbSet<Project> getProjectById { get; set; }

        public DbSet<Project> getProjectCount { get; set; }

        public DbSet<Event> Event { get; set; }
         
       public DbSet<Event> getEvent { get; set; } 

        public DbSet<Event> getEventById { get; set; }

        public DbSet<Event> getEventCount { get; set; }


        public DbSet<Blog> Blog { get; set; }
         
       public DbSet<Blog> getBlog { get; set; } 

        public DbSet<Blog> getBlogById { get; set; }

        public DbSet<Blog> getBlogCount { get; set; }

    }
}