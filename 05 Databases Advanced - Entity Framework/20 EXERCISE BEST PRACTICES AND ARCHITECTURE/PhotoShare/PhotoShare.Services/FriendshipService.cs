namespace PhotoShare.Services
{
    using Microsoft.EntityFrameworkCore;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using System;
    using System.Linq;

    public class FriendshipService : IFriendshipService
    {
        private readonly PhotoShareContext context;

        public FriendshipService(PhotoShareContext context)
        {
            this.context = context;
        }

        public string AcceptFriend(string username, string friendUsername)
        {
            var user = GetUser(username);

            UserExists(username, user);

            var friend = GetUser(friendUsername);

            UserExists(friendUsername, friend);            

            ValidationFriendRelationShip(user, friend);

            var userFriendShep = new Friendship
            {
                User = user,
                Friend = friend
            };

            user.FriendsAdded.Add(userFriendShep);

            context.SaveChanges();

            return $"{username} accepted {friendUsername} as a friend";
        }

        private static void ValidationFriendRelationShip(User user , User friend)
        {
            bool userAlreadyAddedFriend = user.FriendsAdded.Any(u => u.Friend == friend);

            bool friendAlreadyAddedUser = friend.FriendsAdded.Any(u => u.Friend == user);

            if (!friendAlreadyAddedUser)
            {
                throw new InvalidOperationException($"{friend.Username} has not added {user.Username} as a friend");
            }
            else
            {
                if (userAlreadyAddedFriend)
                {
                    throw new InvalidOperationException($"{friend.Username} is already a friend to {user.Username}");
                }
            }
        }

        public string AddFriend(string username, string friendUsername)
        {
            var user = GetUser(username);

            UserExists(username, user);

            var friend = GetUser(friendUsername);

            UserExists(friendUsername, friend);

            bool userAlreadyAddedFriend = user.FriendsAdded.Any(u => u.Friend == friend);

            bool friendAlreadyAddedUser = friend.FriendsAdded.Any(u => u.Friend == user);

            if (userAlreadyAddedFriend)
            {
                if (friendAlreadyAddedUser)
                {
                    throw new InvalidOperationException($"{friendUsername} is already a friend to {username}");
                }
                else
                {
                    throw new ArgumentException($"User {username} already sent friend request to {friendUsername}! It is still not accepted by {friendUsername}!");
                }
            }
            else
            {
                if (friendAlreadyAddedUser)
                {
                    throw new ArgumentException($"User {username} already received friend request to {friendUsername}!It is still not accepted by {username}!");
                }
            }

            var userFriendShep = new Friendship
            {
                User = user,
                Friend = friend
            };

            friend.AddedAsFriendBy.Add(userFriendShep);

            user.FriendsAdded.Add(userFriendShep);

            context.SaveChanges();

            return $"Friend {friendUsername} added to {username}";
        }

        private static void UserExists(string username, User user)
        {
            if (user == null)
            {
                throw new ArgumentException($"{username} not found!");
            }
        }

        private User GetUser(string username)
        {
            return context.Users.Include(u => u.FriendsAdded).ThenInclude(fa => fa.Friend)
                             .SingleOrDefault(u => u.Username == username);
        }
    }
}
