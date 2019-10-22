using FacebookClone.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models.ViewModels.Profile
{
    public class MessageVM
    {

        public MessageVM()
        {

        }

        public MessageVM(Message msg)
        {
            Id = msg.Id;
            From = msg.From;
            To = msg.To;
            MessageText = msg.MessageText;
            DateSent = msg.DateSent;
            Read = msg.Read;

            FromUsername = msg.FromUser.Username;
            FromNameFirst = msg.FromUser.NameFirst;
            FromNameLast = msg.FromUser.NameLast;
        }

        public int Id { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public string MessageText { get; set; }

        public DateTime DateSent { get; set; }

        public bool Read { get; set; }

        public string FromUsername { get; set; }

        public string FromNameFirst { get; set; }

        public string FromNameLast { get; set; }
    }
}