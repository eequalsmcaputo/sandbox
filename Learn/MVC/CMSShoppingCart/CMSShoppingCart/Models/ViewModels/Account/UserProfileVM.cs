using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CMSShoppingCart.Models.Data;

namespace CMSShoppingCart.Models.ViewModels.Account
{
    public class UserProfileVM : UserBase
    {
        public UserProfileVM()
        {

        }

        public UserProfileVM(UserDto row) : base(row)
        {

        }

        [Display(Name = "Confirm Password")]
        public string PasswordConfirm { get; set; }
    }
}