using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FacebookClone.Persistence;
using FacebookClone.Models.Data;

namespace FacebookClone
{
    public class UtilityController : Controller
    {
        protected DB db;
        protected UserUtilities uu;

        public UtilityController()
        {
            uu = new UserUtilities();
            db = uu.db;
        }

        protected DirectoryInfo UploadsDir
        {
            get
            {
                return new DirectoryInfo(string.Format("{0}uploads",
                    Server.MapPath("\\")));
            }
        }

        protected byte[] ConvertImage(HttpPostedFileBase file)
        {
            MemoryStream target = new MemoryStream();
            file.InputStream.CopyTo(target);
            return target.ToArray();
        }

        protected bool SaveFile(HttpPostedFileBase file, User user)
        {
            if (file != null && file.ContentLength > 0)
            {
                if (!HasImageFileExtension(file))
                {
                    ModelState.AddModelError("", "Invalid file extension.");
                    return false;
                }

                string imageName = user.Id.ToString() + ".jpg";
                var path = string.Format("{0}\\{1}", UploadsDir, imageName);
                file.SaveAs(path);
                return true;
            }
            return false;
        }

        protected bool HasImageFileExtension(HttpPostedFileBase file)
        {
            string ext = file.ContentType.ToLower();
            return !(ext != "image/jpg" &&
                ext != "image/jpeg" &&
                ext != "image/pjpeg" &&
                ext != "image/gif" &&
                ext != "image/x-png" &&
                ext != "image/png");
        }

        protected User LoggedInUser
        {
            get
            {
                return db.Users.FirstOrDefault(
                    x => x.Username == User.Identity.Name);
            }
        }
    }
}