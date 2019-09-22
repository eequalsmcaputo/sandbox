using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidzyCodeFirst.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Video> Videos { get; set; }
    }
}