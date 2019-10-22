using FacebookClone.Models.Data;
using FacebookClone.Models.ViewModels.Account;
using FacebookClone.Models.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacebookClone.Controllers
{
    public class ProfileController : UtilityController
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LiveSearch(string searchVal)
        {
            List<LiveSearchUserVM> usernames = db.Users.ToArray()
                .Where(x => x.Username.Contains(searchVal) && x.Username != User.Identity.Name)
                .Select(x => new LiveSearchUserVM(x)).ToList();
            return Json(usernames);
        }

        [HttpPost]
        public void AddFriend(string friend)
        {
            var loggedinuser = LoggedInUser;
            var frienduser = uu.GetUser(friend);

            Friends friends = new Friends(loggedinuser.Id, frienduser.Id);
            friends.Active = false;

            db.Friends.Add(friends);
            db.SaveChanges();
        }

        [HttpPost]
        public JsonResult FriendRequests()
        {
            var loggedInUser = LoggedInUser;

            List<FriendRequestVM> list = db.Friends.Where(
                x => (x.UserId1 == loggedInUser.Id || x.UserId2 == loggedInUser.Id) &&
                x.Active == false).ToArray().Select(
                    x => new FriendRequestVM(x)).ToList();
            List<UserVM> users = new List<UserVM>();

            foreach(var item in list)
            {
                var usr = db.Users.FirstOrDefault(x => x.Id == item.UserId1);
                int id;
                if (usr.Id == item.UserId1)
                {
                    id = item.UserId2;
                } else
                {
                    id = item.UserId1;
                }
                users.Add(new UserVM(usr, id));
            }

            return Json(users);
        }

        [HttpPost]
        public void AcceptFriendRequest(int friendId)
        {
            var loggedInUser = LoggedInUser;

            Friends friends = db.Friends.FirstOrDefault(
                x => (x.UserId1 == friendId && 
                    x.UserId2 == loggedInUser.Id) ||
                (x.UserId2 == friendId && x.UserId1 == loggedInUser.Id));
            friends.Active = true;
            db.SaveChanges();
        }

        [HttpPost]
        public void DeclineFriendRequest(int friendId)
        {
            try
            {
                var loggedInUser = LoggedInUser;

                Friends friends = db.Friends.FirstOrDefault(
                    x => (x.UserId1 == friendId && 
                        x.UserId2 == loggedInUser.Id) ||
                    (x.UserId2 == friendId && 
                        x.UserId1 == loggedInUser.Id));

                db.Friends.Remove(friends);
                db.SaveChanges();
            } catch (Exception e)
            {
                db.ErrorLogs.Add(new Models.ErrorLog(e,
                    "DeclineFriendRequest"));
                db.SaveChanges();
            }
        }

        [HttpPost]
        public void SendMessage(string friend, string message)
        {
            User friendUser = uu.GetUser(friend);

            Message msg = new Message();
            msg.From = LoggedInUser.Id;
            msg.To = friendUser.Id;
            msg.MessageText = message;
            msg.DateSent = DateTime.Now;
            msg.Read = false;

            db.Messages.Add(msg);
            db.SaveChanges();
        }

        [HttpPost]
        public JsonResult UnreadMessages()
        {
            var loggedinuser = LoggedInUser;

            List<Message> messages = db.Messages.Where(
                x => x.To == loggedinuser.Id && x.Read == false)
                .ToList();

            List<MessageVM> messageVMs = messages
                    .ToArray()
                    .Select(x => new MessageVM(x))
                    .ToList();

            messages.ForEach(x => x.Read = true);
            db.SaveChanges();

            return Json(messageVMs);
        }

        public void UpdateWallMessage(int id, string message)
        {
            WallPost wall = db.WallPosts.Find(id);
            if (wall == null)
            {
                wall = new WallPost();
                wall.Id = id;
                db.WallPosts.Add(wall);
            }
            wall.MessageText = message;
            wall.DateEdited = DateTime.Now;
            db.SaveChanges();
        }

        [HttpPost]
        public bool UploadProfileImage()
        {
            HttpPostedFileBase file = Request.Files[0];
            LoggedInUser.ProfileImage = ConvertImage(file);
            db.SaveChanges();
            return true;
        }
    }
}