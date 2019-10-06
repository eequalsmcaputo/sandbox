using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSShoppingCart.Models.Data
{
    [Table("Orders")]
    public class OrderDto
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }

        [ForeignKey("UserId")]
        public virtual UserDto User { get; set; }
        
        /*
        public virtual ICollection<int> OrderDetailIds { get; set; }
        public virtual ICollection<OrderDetailDto> OrderDetails { get; set; }
        */
    }
}