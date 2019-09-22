using System;
using System.Linq;
using System.Data.Entity;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {

            RemoveGenre("Action");

            //RemoveVideo("The Godfather");

            //RemoveTagFromVideo("The Godfather", "comedy");

            /*AddTagToVideo("The Godfather", "classics");
            AddTagToVideo("The Godfather", "drama");
            AddTagToVideo("The Godfather", "comedy");*/

            /*AddTag("classics");
            AddTag("drama");*/

            //AddVideo("Terminator 1", "Action", new DateTime(1984, 10, 26), Classification.Silver);

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private static void RemoveGenre(string name)
        {
            using (var context = new VidzyContext())
            {
                var genre = context.Genres
                    .Where(g => g.Name == name)
                    .FirstOrDefault();

                if(genre != null)
                {
                    context.Videos.RemoveRange(genre.Videos);
                    context.Genres.Remove(genre);
                    context.SaveChanges();
                }
            }
        }

        private static void RemoveVideo(string name)
        {
            using (var context = new VidzyContext())
            {
                var video = context.Videos
                    .Where(v => v.Name == name)
                    .FirstOrDefault();

                if(video != null)
                {
                    context.Videos.Remove(video);
                    context.SaveChanges();
                }
            }
        }

        private static void RemoveTagFromVideo(string videoName, string tagName)
        {
            using (var context = new VidzyContext())
            {
                var tag = context.Tags
                    .Where(t => t.Name == tagName)
                    .FirstOrDefault();

                if(tag != null)
                {
                    var video = context.Videos
                        .Where(v => v.Name == videoName)
                        .FirstOrDefault();

                    if(video != null)
                    {
                        video.Tags.Remove(tag);
                        context.SaveChanges();
                    }
                }
            }
        }

        private static void AddTagToVideo(string videoName, string tagName)
        {

            using (var context = new VidzyContext())
            {
                Tag newTag = context.Tags
                    .Where(t => t.Name == tagName)
                    .FirstOrDefault();

                if (newTag == null)
                {
                    newTag = new Tag
                    {
                        Name = tagName
                    };

                    context.Tags.Add(newTag);
                    context.SaveChanges();
                }

                var video = context.Videos
                    .Where(v => v.Name == videoName)
                    .FirstOrDefault();

                var videoTag = video.Tags
                    .Where(t => t.Name == tagName)
                    .FirstOrDefault();

                if(videoTag == null)
                {
                    video.Tags.Add(newTag);
                }

                context.SaveChanges();
            }
        }

        private static void AddVideo(string name, string genreName, DateTime releaseDate,
            Classification classification)
        {
            using (var context = new VidzyContext())
            {
                var genre = context.Genres
                    .Where(g => g.Name == genreName)
                    .First();

                var video = new Video()
                {
                    Name = name,
                    Genre = genre,
                    ReleaseDate = releaseDate,
                    Classification = classification
                };

                context.Videos.Add(video);
                context.SaveChanges();
            }
        }
    }
}
