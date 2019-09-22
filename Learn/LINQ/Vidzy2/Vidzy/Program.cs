using System;
using System.Linq;
using System.Data.Entity;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();

            var videos = context.Videos.Include(v => v.Genre).ToList();
            // Lazy Loading
            //var videos = context.Videos.ToList();

            foreach(var video in videos)
            {
                Console.WriteLine("{0}: {1}", video.Name, video.Genre.Name);
            }

            Console.ReadLine();
        }
    }
}
