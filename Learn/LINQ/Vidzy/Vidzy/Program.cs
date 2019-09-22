using System;
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();

            var genres = context.Genres
                .GroupJoin(context.Videos,
                    g => g.Id,
                    v => v.GenreId,
                    (genre, videos) => new
                    {
                        Genre = genre.Name,
                        Videos = videos.Count()
                    }).OrderByDescending(g => g.Videos);

            foreach(var g in genres)
            {
                Console.WriteLine(g.Genre + " (" + g.Videos.ToString() + ")");
            }

            /*foreach(Classification c in Enum.GetValues(typeof(Classification)))
            {
                var cnt = context.Videos
                    .Where(v => v.Classification == c)
                    .Count();

                Console.WriteLine(c.ToString() + "(" + cnt + ")");
            }*/

            /*var groups = context.Videos
                .GroupBy(v => v.Classification)
                .Select(g => new { Classification = g.Key, Videos = g });

            foreach(var c in groups)
            {
                Console.WriteLine("Classification: " + c.Classification.ToString());

                foreach(var v in c.Videos)
                {
                    Console.WriteLine("\t" + v.Name);
                }
            }*/

            /*var query = context.Videos
                .Where(v => v.Genre.Name == "Action")
                .OrderBy(v => v.Name);*/

            /*var query = context.Videos
                .Where(v => v.Classification == Classification.Gold)
                .Where(v => v.Genre.Name == "Drama")
                .OrderByDescending(v => v.ReleaseDate);*/

            /*var query = context.Videos
                .Select(v => new
                {
                    Name = v.Name,
                    Genre = v.Genre.Name
                });

            foreach(var video in query)
            {
                Console.WriteLine(video.Name);
            }*/

            Console.ReadLine();
        }
    }
}
