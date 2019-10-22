using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacebookClone.Models.Data
{
    public class WallPost
    {
        public int Id { get; set; }

        public string MessageText { get; set; }

        public DateTime DateEdited { get; set; }

        [ForeignKey("Id")]
        public virtual User User { get; set; }
    }
}