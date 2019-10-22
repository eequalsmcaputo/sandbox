using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using FacebookClone.Persistence;
using FacebookClone.Models.Data;
using System.Web.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FacebookClone
{
    [HubName("echo")]
    public class EchoHub : Hub
    {
        DB db;
        UserUtilities uu;

        public EchoHub()
        {
            uu = new UserUtilities();
            db = uu.db;
        }

        public void Hello(string message)
        {
            var clients = Clients.All;
            clients.test(message);
        }

        public void Notify(string friend)
        {
            User user = db.Users.FirstOrDefault(x => x.Username == friend);
            var friendReqCount = db.Friends.Count(x => x.UserId2 == user.Id &&
                x.Active == false);
            Trace.WriteLine("*****test*****");
            var clients = Clients.Others;
            clients.frnotify(friend, friendReqCount);
        }

        public void getFRCount()
        {
            User user = db.Users.FirstOrDefault(
                x => x.Username == Context.User.Identity.Name);
            var frCount = db.Friends.Count(x => x.UserId2 == user.Id &&
                x.Active == false);

            var clients = Clients.Caller;
            clients.frcount(Context.User.Identity.Name, frCount);
        }

        public void getFriendCount(int friendId)
        {
            var loggedInUser = LoggedInUser;
            var friendUser = db.Users.FirstOrDefault(
                x => x.Id == friendId);

            var friendCountLoggedIn = db.Friends.Count(x =>
                (x.UserId2 == friendId ||
                x.UserId1 == friendId) && x.Active == true);

            var friendCountFriend = db.Friends.Count(x =>
                (x.UserId2 == friendId ||
                x.UserId1 == friendId) && x.Active == true);

            UpdateChat();

            var clients = Clients.All;
            clients.friendCount(loggedInUser.Username, friendUser.Username,
                friendCountLoggedIn, friendCountFriend);
        }

        public void updateWallMessage(int fromUserId, string message)
        {
            List<int> onlineFriends = uu.GetOnlineFriendIds(
                uu.GetFriendIds(fromUserId));
            var clients = Clients.Others;
            clients.updateWallMessage(fromUserId, message);
        }

        public void notifyOfMessage(string friend)
        {
            var friendUser = uu.GetUser(friend);
            notifyMsg(friendUser, ClientsTypes.Others);
        }

        public void notifyOfMessageOwner()
        {
            notifyMsg(LoggedInUser, ClientsTypes.Caller);
        }

        private void notifyMsg(User user, ClientsTypes clientsType)
        {
            var messageCount = db.Messages.Count(
                x => x.To == user.Id && x.Read == false);

            switch(clientsType)
            {
                case ClientsTypes.All:
                    Clients.All.msgcount(user.Username, messageCount);
                    break;
                case ClientsTypes.Caller:
                    Clients.Caller.msgcount(user.Username, messageCount);
                    break;
                case ClientsTypes.Others:
                    Clients.Others.msgcount(user.Username, messageCount);
                    break;
                default:
                    break;
            }
        }

        public override Task OnConnected()
        {
            Trace.WriteLine("Here I am " + Context.ConnectionId);
            var loggedInUser = LoggedInUser;

            if(!db.OnlineUsers.Any(x => x.Id == loggedInUser.Id))
            {
                OnlineUser ou = new OnlineUser()
                {
                    Id = loggedInUser.Id,
                    ConnId = Context.ConnectionId
                };

                db.OnlineUsers.Add(ou);
                db.SaveChanges();
            }

            List<int> onlineFriends = uu.GetOnlineFriendIds(
                uu.GetFriendIds(loggedInUser.Id));

            string json = uu.GetOnlineFriendsJson(onlineFriends);
            var clients = Clients.Caller;
            clients.getOnlineFriends(json, Context.User.Identity.Name);

            UpdateChat();

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {

            Trace.WriteLine("Disconnected: " + Context.User.Identity.Name +
                " (" + Context.ConnectionId + ")");

            User loggedInUser = LoggedInUser;

            if(db.OnlineUsers.Any(x => x.Id == loggedInUser.Id))
            {
                OnlineUser ou = db.OnlineUsers.Find(loggedInUser.Id);
                db.OnlineUsers.Remove(ou);
                db.SaveChanges();
            }

            UpdateChat();

            return base.OnDisconnected(stopCalled);
        }

        private void UpdateChat()
        {
            List<int> onlineIds = db.OnlineUsers.ToArray()
                .Select(x => x.Id).ToList();

            foreach(var id in onlineIds)
            {
                User user = db.Users.Find(id);

                List<int> onlineFriends = uu.GetOnlineFriendIds(
                uu.GetFriendIds(id));

                string json = uu.GetOnlineFriendsJson(onlineFriends);

                var clients = Clients.All;
                clients.updateChat(json, user.Username);
            }
        }

        public void sendChat(int friendId, string friendUsername, string message)
        {
            var loggedInUser = LoggedInUser;
            var clients = Clients.All;
            clients.sendChat(loggedInUser.Id, loggedInUser.Username,
                friendId, friendUsername, message);
        }

        #region utilities

        private enum ClientsTypes
        {
            All,
            Others,
            Caller
        }

        private User LoggedInUser
        {
            get
            {
                return db.Users.FirstOrDefault(
                    x => x.Username == Context.User.Identity.Name);
            }
        }

        #endregion
    }
}