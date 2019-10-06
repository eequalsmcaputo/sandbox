using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSShoppingCart
{
    public class OrdersForBase
    {
        [Display(Name = "Order Number")]
        public int OrderNumber { get; set; }

        [Display(Name = "User")]
        public decimal Total { get; set; }
        public Dictionary<string, short> ProductAndQty { get; set; }

        [Display(Name = "Order Date")]
        public DateTime CreateOn { get; set; }
    }
}