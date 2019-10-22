using FacebookClone.Persistence;
using FacebookClone.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace FacebookClone
{
    public class UserUtilities
    {
        public DB db = new DB();

        public User GetUser(int userId)
        {
            return db.Users.Find(userId);
        }

        public User GetUser(string username)
        {
            return db.Users.FirstOrDefault(
                x => x.Username == username);
        }

        public List<int> GetFriendIds(int userId)
        {
            List<int> friendIds1 = db.Friends.Where(
                x => x.UserId1 == userId && x.Active == true)
                .ToArray()
                .Select(x => x.UserId2)
                .ToList();

            List<int> friendIds2 = db.Friends.Where(
                x => x.UserId2 == userId && x.Active == true)
                .ToArray()
                .Select(x => x.UserId1)
                .ToList();

            return friendIds1.Concat(friendIds2).ToList();
        }

        public List<int> GetOnlineFriendIds(List<int> friendIds)
        {
            List<int> onlineIds = db.OnlineUsers.ToArray()
                .Select(x => x.Id).ToList();

            return onlineIds.Where((i) => friendIds.Contains(i))
                .ToList();
        }

        public Dictionary<int, string> GetOnlineFriendsDict(List<int> onlineFriends)
        {
            Dictionary<int, string> friendsdict = new Dictionary<int, string>();

            foreach (var id in onlineFriends)
            {
                var user = db.Users.Find(id);

                if (!friendsdict.ContainsKey(id))
                {
                    friendsdict.Add(id, user.Username);
                }
            }

            return friendsdict;
        }

        public string GetOnlineFriendsJson(List<int> onlineFriends)
        {
            Dictionary<int, string> friendsdict = 
                GetOnlineFriendsDict(onlineFriends);

            var transformed = from key in friendsdict.Keys
                              select new { id = key, friend = friendsdict[key] };

            return JsonConvert.SerializeObject(transformed);
        }
    }
}