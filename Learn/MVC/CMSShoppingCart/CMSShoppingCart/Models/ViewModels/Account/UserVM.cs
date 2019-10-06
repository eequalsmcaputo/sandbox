using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CMSShoppingCart.Models.Data;

namespace CMSShoppingCart.Models.ViewModels.Account
{
    public class UserVM : UserBase
    {
        public UserVM()
        {

        }

        public UserVM(UserDto row) : base(row)
        {
        }

        [Required]
        public new string Password
        {
            get
            {
                return base.Password;
            }
            set
            {
                base.Password = value;
            }
        }

        [Required]
        [Display(Name = "Confirm Password")]
        public string PasswordConfirm { get; set; }
    }
}