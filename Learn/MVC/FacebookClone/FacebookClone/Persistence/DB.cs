using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FacebookClone.Models;
using FacebookClone.Models.Data;

namespace FacebookClone.Persistence
{
    public class DB : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Friends> Friends { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<WallPost> WallPosts { get; set; }
        public DbSet<OnlineUser> OnlineUsers { get; set; }
    }
}