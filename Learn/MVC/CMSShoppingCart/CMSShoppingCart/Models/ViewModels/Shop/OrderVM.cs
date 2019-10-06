using CMSShoppingCart.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSShoppingCart.Models.ViewModels.Shop
{
    public class OrderVM
    {
        public OrderVM()
        {

        }

        public OrderVM(OrderDto row)
        {
            OrderId = row.OrderId;
            UserId = row.UserId;
            CreatedOn = row.CreatedOn;
        }

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}