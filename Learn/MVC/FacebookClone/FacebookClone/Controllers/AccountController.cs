using FacebookClone.Models.Data;
using FacebookClone.Models.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FacebookClone.Controllers
{
    public class AccountController : UtilityController
    {

        public enum UserTypes : byte
        {
            guest,
            owner
        }

        public enum FriendsTypes : byte
        {
            notfriends,
            pending,
            friends
        }

        public ActionResult Index()
        {
            string username = User.Identity.Name;

            if(!string.IsNullOrEmpty(username))
            {
                return Redirect("~/" + username);
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateAccount(User model, 
            HttpPostedFileBase file)
        {
            if(!ModelState.IsValid)
            {
                return View("Index", model);
            }

            if(db.Users.Any(u => u.Username == model.Username))
            {
                ModelState.AddModelError("", "Username " + model.Username +
                    " is taken.");
                model.Username = "";
                return View("Index", model);
            }

            db.Users.Add(model);
            db.SaveChanges();

            FormsAuthentication.SetAuthCookie(model.Username, false);

            model.ProfileImage = ConvertImage(file);

            WallPost wall = new WallPost() {
                Id = model.Id,
                MessageText = "",
                DateEdited = DateTime.Now
            };

            db.WallPosts.Add(wall);
            db.SaveChanges();

            return Redirect("~/" + model.Username);
        }

        [Authorize]
        public ActionResult Dashboard(string username = "")
        {
            // Check for existence of user
            if(!db.Users.Any(x => x.Username == username))
            {
                return Redirect("~/");
            }

            // Viewbag username
            ViewBag.Username = username;


            // Get user objects
            User loggedInUser = LoggedInUser;
            ViewBag.NameFull = loggedInUser.NameFull;

            User viewingUser = db.Users.FirstOrDefault(x => x.Username == username);
            ViewBag.ViewingNameFull = viewingUser.NameFull;
            ViewBag.UsernameImage = viewingUser.UsernameImage;

            // Determine UserType and Viewbag it
            UserTypes userType = UserTypes.guest;
            if(username == loggedInUser.Username)
            {
                userType = UserTypes.owner;
            }
            ViewBag.UserType = userType;


            // If UserType is guest, determine FriendsType
            if(userType == UserTypes.guest)
            {
                Friends f1 = db.Friends.FirstOrDefault(
                    x => x.UserId1 == loggedInUser.Id &&
                    x.UserId2 == viewingUser.Id);
                Friends f2 = db.Friends.FirstOrDefault(
                    x => x.UserId1 == viewingUser.Id &&
                    x.UserId2 == loggedInUser.Id);

                ViewBag.FriendsType = GetFriendsType(f1, f2);
                ViewBag.UserId = viewingUser.Id;
            } else
            {
                ViewBag.UserId = loggedInUser.Id;
            }

            
            // Get Friend Request count
            var friendReqCount = db.Friends.Count(x =>
                (x.UserId1 == loggedInUser.Id || 
                    x.UserId2 == loggedInUser.Id) &&
                    x.Active == false);

            // Viewbag FR count if > 0
            if(friendReqCount > 0)
            {
                ViewBag.FriendReqCount = friendReqCount;
            }


            // Viewbag Friend Count
            ViewBag.FriendCount = db.Friends.Count(x => 
                (x.UserId2 == loggedInUser.Id ||
                x.UserId1 == loggedInUser.Id) && x.Active == true);


            // Viewbag Message count
            ViewBag.MessageCount = db.Messages.Count(
                x => x.To == loggedInUser.Id && x.Read == false);

            ViewBag.WallMessage = db.WallPosts.Where(
                x => x.Id == loggedInUser.Id).Select(x => x.MessageText)
                .FirstOrDefault();

            List<int> friendIds = uu.GetFriendIds(loggedInUser.Id);

            List <WallPostVM> walls = db.WallPosts.Where(
                x => friendIds.Contains(x.Id))
                .ToArray()
                .OrderByDescending(x => x.DateEdited)
                .Select(x => new WallPostVM(x))
                .ToList();

            ViewBag.Walls = walls;

            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("~/");
        }

        public ActionResult LoginPartial()
        {

            return PartialView();
        }

        [HttpPost]
        public string Login(string username, string password)
        {
            if(db.Users.Any(x => x.Username == username && x.Password == password))
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return "ok";
            }
            return "invalid";
        }

        #region utilities

        private FriendsTypes GetFriendsType(Friends f1, Friends f2)
        {
            if (f1 == null && f2 == null)
            {
                return FriendsTypes.notfriends;
            }
            else
            {
                if(f1 != null)
                {
                    return GetFriendsType(f1);
                } else
                {
                    return GetFriendsType(f2);
                }
            }
        }

        private FriendsTypes GetFriendsType(Friends f)
        {
            if (f.Active)
            {
                return FriendsTypes.friends;
            }
            else
            {
                return FriendsTypes.pending;
            }
        }

        #endregion
    }
}