using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacebookClone.Models.Data
{
    public class OnlineUser
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string ConnId { get; set; }

        [ForeignKey("Id")]
        public virtual User User { get; set; }
    }
}