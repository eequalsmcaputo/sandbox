using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormTagHelpers.Models
{
    public class Fruit
    {

        [Display(Name = "Name: ")]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "$0:F2")]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "0:F2", ApplyFormatInEditMode = true)]
        public int Qty { get; set; }
    }
}
