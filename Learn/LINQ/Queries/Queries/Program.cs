using System;
using System.Linq;
using System.Data.Entity;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            #region Working with Change Tracker

            // Add
            context.Authors.Add(new Author { Name = "New Author" });

            // Update
            var author = context.Authors.Find(3);
            author.Name = "Updated";

            // Delete
            var another = context.Authors.Find(4);
            context.Authors.Remove(another);

            var entries = context.ChangeTracker.Entries();

            foreach(var entry in entries)
            {
                entry.Reload();
                Console.WriteLine(entry.State);
            }

            #endregion

            #region Deleting

            // Deleting child records when cascade delete is enabled
            /*var author = context.Authors
                .Include(a => a.Courses)
                .Single(a => a.Id == 2);
            context.Courses.RemoveRange(author.Courses);
            context.Authors.Remove(author);*/

            // Basic Deletion
            /*var course = context.Courses.Find(6);
            context.Courses.Remove(course);*/

            //context.SaveChanges();

            #endregion

            #region Updating

            /*var course = context.Courses.Find(4);
            course.Name = "New Name";
            course.AuthorId = 2;

            context.SaveChanges();*/

            #endregion

            #region Adding

            /*var authors = context.Authors.ToList();
            var author = authors.Where(a => a.Id == 1).First();

            var course = new Course
            {
                Name = "New Course",
                Description = "New Description",
                Level = 1,
                FullPrice = 19.95f,
                //Author = author
                AuthorId = 1
            };

            context.Courses.Add(course);
            context.SaveChanges();*/

            #endregion

            // IQueryable vs IEnumerable
            // IQueryable uses deferred execution; IEnumerable does not
            /*IQueryable<Course> courses = context.Courses;
            var filtered = courses.Where(c => c.Level == 1);
            foreach(var course in filtered)
            {
                Console.WriteLine(course.Name);
            }*/


            // Extension Methods
            /*var courses = context.Courses
                .Where(c => c.Name.Contains("C#"))
                .OrderBy(c => c.Name);

            foreach(var course in courses)
            {
                Console.WriteLine(course.Name);
            }*/

            #region Extension Methods

            // Aggregating
            //var max = context.Courses.Max(c => c.FullPrice);

            // Quantifying
            //bool allAbove10Dollars = context.Courses.All(c => c.FullPrice > 10);

            // Element Operators
            /*var first = context.Courses
                .OrderBy(c => c.Level)
                .FirstOrDefault(c => c.FullPrice > 100);

            context.Courses.SingleOrDefault(c => c.Id == 1);*/

            // Partitioning
            //var courses = context.Courses.Skip(10).Take(10);

            // Joins - Cross
            /*var query = context.Authors
                .SelectMany(a => context.Courses,
                    (author, course) => new
                    {
                        AuthorName = author.Name,
                        CourseName = course.Name
                    });

            foreach(var x in query)
            {
                Console.WriteLine("{0} - {1}", x.AuthorName, x.CourseName);
            }*/

            // Joins - Group
            /*var query = context.Authors.GroupJoin(
                context.Courses,
                a => a.Id,
                c => c.AuthorId,
                (author, courses) => new
                {
                    AuthorName = author.Name,
                    Courses = courses.Count()
                });

            foreach(var a in query)
            {
                Console.WriteLine("{0}: {1}", a.AuthorName, a.Courses);
            }*/

            // Joins - Inner
            /*var query = context.Courses
                .Join(context.Authors, c => c.AuthorId, a => a.Id,
                (course, author) => new
                {
                    CourseName = course.Name,
                    AuthorName = author.Name
                });

            foreach(var x in query)
            {
                Console.WriteLine("{0}: {1}", x.AuthorName, x.CourseName);
            }*/

            // Grouping
            /*var groups = context.Courses
                .GroupBy(c => c.Level);

            foreach(var group in groups)
            {
                Console.WriteLine("Key: " + group.Key);

                foreach(var course in group)
                {
                    Console.WriteLine("\t" + course.Name);
                }
            }*/

            // Restriction, Ordering, Projection, Set Ops

            /*var query = context.Courses
                .Where(c => c.Level > 1)
                .OrderBy(c => c.Name)
                .ThenByDescending(c => c.Level)

                // Projection
                //.Select(c => new { CourseName = c.Name, AuthorName = c.Author.Name });

                // Return list of lists
                //.Select(c => c.Tags);

                // Return flattened list
                .SelectMany(c => c.Tags)

                .Distinct();

            foreach(var tag in query)
            {
                Console.WriteLine(tag.Name);
            }*/

            #endregion

            // LINQ Syntax
            /*var query =
                from c in context.Courses
                where c.Name.Contains("C#")
                orderby c.Name
                select c;

            foreach(var course in query)
            {
                Console.WriteLine(course.Name);
            }*/

            #region LINQ Syntax
            // Joins - Cross
            /*var query =
                from a in context.Authors
                from c in context.Courses
                select new { AuthorName = a.Name, CourseName = c.Name };

            foreach(var x in query)
            {
                Console.WriteLine("{0} - {1}", x.AuthorName, x.CourseName);
            }*/

            // Joins - Group
            /*var query =
                from a in context.Authors
                join c in context.Courses on a.Id equals c.AuthorId
                into g
                select new { AuthorName = a.Name, Courses = g.Count() };

            foreach(var x in query)
            {
                Console.WriteLine("{0} ({1})", x.AuthorName, x.Courses);
            }*/

            // Joins - Inner
            /*var query =
                from c in context.Courses
                join a in context.Authors on c.AuthorId equals a.Id
                select new { CourseName = c.Name, AuthorName = a.Name };*/

            // Grouping
            /*var query =
                from c in context.Courses
                group c by c.Level
                into g
                select g;

            foreach(var group in query)
            {
                Console.WriteLine("{0} ({1})", group.Key, group.Count());

                // Detail
                foreach(var course in group)
                {
                    Console.WriteLine("\t{0}", course.Name);
                }
            }*/

            // Projection
            /*var query =
                from c in context.Courses
                where c.Level == 1
                    && c.Author.Id == 1
                orderby c.Level descending, c.Name
                select new { Name = c.Name, Author = c.Author.Name };

            foreach (var course in query)
            {
                Console.WriteLine(course.Name);
            }*/

            #endregion

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
