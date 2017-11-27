namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Commands.Contracts;
    using PhotoShare.Services.Contracts;
    using System;

    public class AcceptFriendCommand : ICommand
    {
        private readonly IFriendshipService friendshipService;

        public AcceptFriendCommand(IFriendshipService friendshipService)
        {
            this.friendshipService = friendshipService;
        }

        // AcceptFriend <username1> <username2>
        public string Execute(string command, string[] data)
        {
            if (Session.User == null)
            {
                throw new ArgumentException("You should login first!");
            }

            if (data.Length < 2)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            string username1 = data[0];

            if (username1 != Session.User.Username)
            {
                throw new InvalidOperationException($"Invalid credentials!");
            }

            string username2 = data[1];

            return friendshipService.AcceptFriend(username1, username2);
        }
    }
}
