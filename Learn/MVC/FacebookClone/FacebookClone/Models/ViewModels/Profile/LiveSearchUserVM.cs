using FacebookClone.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models.ViewModels.Profile
{
    public class LiveSearchUserVM
    {
        public LiveSearchUserVM()
        {

        }

        public LiveSearchUserVM(User user)
        {
            UserId = user.Id;
            NameFirst = user.NameFirst;
            NameLast = user.NameLast;
            Username = user.Username;
        }

        public int UserId { get; set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string Username { get; set; }
    }
}