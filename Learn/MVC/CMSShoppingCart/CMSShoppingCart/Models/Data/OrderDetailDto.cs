using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSShoppingCart.Models.Data
{
    [Table("OrderDetails")]
    public class OrderDetailDto
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Int16 Quantity { get; set; }

        [ForeignKey("OrderId")]
        public OrderDto Order { get; set; }

        [ForeignKey("ProductId")]
        public ProductDto Product { get; set; }
    }
}