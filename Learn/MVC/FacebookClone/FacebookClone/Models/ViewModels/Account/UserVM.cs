using FacebookClone.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models.ViewModels.Account
{
    public class UserVM
    {

        public UserVM()
        {

        }

        public UserVM(User user, int frientId)
        {
            Id = user.Id;
            Username = user.Username;
            NameFirst = user.NameFirst;
            NameLast = user.NameLast;
            FriendId = frientId;
        }
        public int Id { get; set; }

        public string Username { get; set; }

        public string NameFirst { get; set; }

        public string NameLast { get; set; }

        public int FriendId { get; set; }
    }
}