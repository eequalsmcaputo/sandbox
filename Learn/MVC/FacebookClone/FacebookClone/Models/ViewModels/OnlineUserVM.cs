using FacebookClone.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models.ViewModels
{
    public class OnlineUserVM
    {

        public OnlineUserVM()
        {

        }

        public OnlineUserVM(OnlineUser user)
        {
            Id = user.Id;
            ConnId = user.ConnId;
        }

        public int Id { get; set; }

        public string ConnId { get; set; }
    }
}