using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacebookClone.Controllers
{
    public class ImageController : UtilityController
    {
        // GET: Image
        public ActionResult Show(int id)
        {
            var user = uu.GetUser(id);
            return File(user.ProfileImage, "image/jpg");
        }
    }
}