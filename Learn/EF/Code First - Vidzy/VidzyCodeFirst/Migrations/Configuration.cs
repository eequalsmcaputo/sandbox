namespace VidzyCodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VidzyCodeFirst.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<VidzyCodeFirst.Models.VidzyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VidzyCodeFirst.Models.VidzyContext context)
        {
            context.Genres.AddOrUpdate(g => g.Name,
                new Genre()
                {
                    Name = "Science Fiction"
                },
                new Genre()
                {
                    Name = "Action"
                },
                new Genre()
                {
                    Name = "Comedy"
                });
        }
    }
}
