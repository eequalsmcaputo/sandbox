using FacebookClone.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models.ViewModels.Profile
{
    public class WallPostVM
    {
        public WallPostVM()
        {

        }

        public WallPostVM(WallPost post)
        {
            Id = post.Id;
            MessageText = post.MessageText;
            DateEdited = post.DateEdited;
        }

        public int Id { get; set; }

        public string MessageText { get; set; }

        public DateTime DateEdited { get; set; }
    }
}