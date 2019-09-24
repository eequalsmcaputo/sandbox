using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMSShoppingCart.Models.Data
{
    public class DB : DbContext
    {

        public DB() : base("CMSSCDB")
        {

        }
        public DbSet<PageDto> Pages { get; set; }
        public DbSet<SidebarDto> Sidebars { get; set; }
    }
}