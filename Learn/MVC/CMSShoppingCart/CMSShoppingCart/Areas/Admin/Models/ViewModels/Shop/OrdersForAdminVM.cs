using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSShoppingCart.Areas.Admin.Models.ViewModels.Shop
{
    public class OrdersForAdminVM : OrdersForBase
    {
        [Display(Name = "User")]
        public string Username { get; set; }
    }
}