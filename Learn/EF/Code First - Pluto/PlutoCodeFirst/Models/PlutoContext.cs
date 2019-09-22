using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PlutoCodeFirst.Models
{
    public class PlutoContext : DbContext
    {
        public PlutoContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}