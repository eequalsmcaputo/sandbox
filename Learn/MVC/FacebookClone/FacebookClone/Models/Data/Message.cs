using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacebookClone.Models.Data
{
    public class Message
    {
        public int Id { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public string MessageText { get; set; }

        public DateTime DateSent { get; set; }

        public bool Read { get; set; }

        [ForeignKey("From")]
        public virtual User FromUser { get; set; }

        [ForeignKey("To")]
        public virtual User ToUser { get; set; }
    }
}