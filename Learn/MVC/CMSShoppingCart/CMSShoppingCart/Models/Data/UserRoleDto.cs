using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSShoppingCart.Models.Data
{
    [Table("UserRoles")]
    public class UserRoleDto
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        [Key, Column(Order = 1)]
        public int RoleId { get; set; }


        [ForeignKey("UserId")]
        public virtual UserDto User { get; set; }

        [ForeignKey("RoleId")]
        public virtual RoleDto Role { get; set; }
    }
}