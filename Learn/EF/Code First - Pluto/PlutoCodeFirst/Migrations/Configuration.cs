namespace PlutoCodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<PlutoCodeFirst.Models.PlutoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PlutoCodeFirst.Models.PlutoContext context)
        {
            context.Authors.AddOrUpdate(a => a.Name,
                new Author()
                {
                    Name = "Author 1",
                    Courses = new List<Course>()
                    {
                        new Course()
                        {
                            Name = "Course For Author 1", Description = "Description"
                        }
                    }
                });
        }
    }
}
