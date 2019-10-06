using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSShoppingCart.Models.ViewModels.Account
{
    public class UserNavPartialVM
    {
        [Display(Name = "First Name")]
        public string NameFirst { get; set; }

        [Display(Name = "Last Name")]
        public string NameLast { get; set; }
    }
}