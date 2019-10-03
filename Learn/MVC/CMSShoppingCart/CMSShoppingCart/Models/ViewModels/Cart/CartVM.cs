using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSShoppingCart.Models.ViewModels.Cart
{
    public class CartVM
    {
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        public string PrdouctName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal Total {
            get
            {
                return Price * Quantity;
            }
        }

        public string Image { get; set; }
    }
}