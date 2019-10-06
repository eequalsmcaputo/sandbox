using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CMSShoppingCart.Models.Data;

namespace CMSShoppingCart.Models.ViewModels.Account
{
    public abstract class UserBase
    {
        public UserBase()
        {

        }

        public UserBase(UserDto row)
        {
            Map(this, row);
        }

        public static void Map(UserBase user, UserDto dto, 
            bool skipPassword = false)
        {
            user.Id = dto.Id;
            user.NameFirst = dto.NameFirst;
            user.NameLast = dto.NameLast;
            user.Email = dto.Email;
            user.Username = dto.Username;
            if(!skipPassword)
            {
                user.Password = dto.Password;
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
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        public string Password { get; set; }
    }
}