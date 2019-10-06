using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace CMSShoppingCart
{
    public class UtilityController : Controller
    {
        protected IEnumerable<string> GetGalleryImages(int id)
        {
            return Directory.EnumerateFiles(
                    Server.MapPath("~/Images/Upload/Products/" +
                        id.ToString() + "/Gallery/Thumbs"))
                    .Select(fn => Path.GetFileName(fn));
        }

        protected void SendTestEmail(string fromAddress, string toAddress,
            string subject, string body)
        {
            var client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("30d7d1cbe02038", "f25eeecfff0fdf"),
                EnableSsl = true
            };
            client.Send(fromAddress, toAddress, subject, body);

        }
    }
}