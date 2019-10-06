using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CMSShoppingCart.Models.ViewModels.Account;

namespace CMSShoppingCart.Models.Data
{
    [Table("Users")]
    public class UserDto
    {

        public UserDto()
        {

        }

        public UserDto(UserBase row)
        {
            Map(this, row);
        }

        public static void Map(UserDto dto, UserBase user,
            bool skipPassword = false)
        {
            dto.NameFirst = user.NameFirst;
            dto.NameLast = user.NameLast;
            dto.Email = user.Email;
            dto.Username = user.Username;
            if(!skipPassword)
            {
                dto.Password = user.Password;
            }
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string NameFirst { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string NameLast { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}