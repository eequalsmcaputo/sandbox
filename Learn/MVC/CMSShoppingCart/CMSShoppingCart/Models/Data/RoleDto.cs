using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSShoppingCart.Models.Data
{
    [Table("Roles")]
    public class RoleDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}