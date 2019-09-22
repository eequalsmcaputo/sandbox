using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VidzyCodeFirst.Models
{
    public class VidzyContext : DbContext
    {
        public VidzyContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Configurations
                .Add(new EntityConfigurations.VideoConfiguration());

            modelBuilder
                .Configurations
                .Add(new EntityConfigurations.GenreConfiguration());

            modelBuilder
                .Configurations
                .Add(new EntityConfigurations.TagConfiguration());
        }
    }
}