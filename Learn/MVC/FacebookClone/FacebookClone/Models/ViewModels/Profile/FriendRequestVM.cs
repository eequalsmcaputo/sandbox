using FacebookClone.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models.ViewModels.Profile
{
    public class FriendRequestVM
    {
        public FriendRequestVM()
        {

        }

        public FriendRequestVM(Friends friends)
        {
            UserId1 = friends.UserId1;
            UserId2 = friends.UserId2;
            Active = friends.Active;
        }

        public int UserId1 { get; set; }
        public int UserId2 { get; set; }
        public bool Active { get; set; }
    }
}