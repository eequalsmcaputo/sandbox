using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidzyCodeFirst.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Video> Videos { get; set; }

    }
}