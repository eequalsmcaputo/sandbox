using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacebookClone.Models.Data
{
    public class Friends
    {
        public Friends()
        {

        }

        public Friends(int userId1, int userId2)
        {
            UserId1 = userId1;
            UserId2 = userId2;
        }

        [Key, Column(Order = 1), Required, ForeignKey("User1")]
        public int UserId1 { get; set; }
        
        [ForeignKey("UserId1")]
        public virtual User User1 { get; set; }

        [Key, Column(Order = 2), Required, ForeignKey("User2")]
        public int UserId2 { get; set; }

        [ForeignKey("UserId2")]
        public virtual User User2 { get; set; }

        public bool Active { get; set; }

        public bool AreConnected(int userId1, int userId2)
        {
            return (UserId1 == userId1 && UserId2 == userId2 ||
                UserId1 == userId2 && UserId2 == userId1);
        }
    }
}