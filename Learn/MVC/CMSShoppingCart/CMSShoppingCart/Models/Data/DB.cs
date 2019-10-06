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
        public DbSet<CategoryDto> Categories { get; set; }
        public DbSet<ProductDto> Products { get; set; }
        public DbSet<UserDto> Users { get; set; }
        public DbSet<RoleDto> Roles { get; set; }
        public DbSet<UserRoleDto> UserRoles { get; set; }
        public DbSet<OrderDto> Orders { get; set; }
        public DbSet<OrderDetailDto> OrderDetails { get; set; }
    }
}