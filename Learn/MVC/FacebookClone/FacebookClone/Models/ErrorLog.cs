using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacebookClone.Models
{
    public class ErrorLog
    {
        public ErrorLog()
        {

        }

        public ErrorLog(Exception e, string member)
        {
            Member = member;
            Message = e.Message;
            StackTrace = e.StackTrace;
        }

        public int Id { get; set; }

        [MaxLength(255)]
        public string Member { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}