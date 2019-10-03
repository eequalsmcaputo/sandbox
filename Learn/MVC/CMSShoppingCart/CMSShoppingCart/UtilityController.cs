using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

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
    }
}