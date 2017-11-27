namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Commands.Contracts;
    using PhotoShare.Services.Contracts;
    using System;

    public class AddFriendCommand : ICommand
    {
        private readonly IFriendshipService friendshipService;

        public AddFriendCommand(IFriendshipService friendshipService)
        {
            this.friendshipService = friendshipService;
        }

        // AddFriend <username1> <username2>
        public string Execute(string command , string[] data)
        {
            if (Session.User == null)
            {
                throw new ArgumentException("You should login first!");
            }

            if (data.Length < 2)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            string username = data[0];

            if (username != Session.User.Username)
            {
                throw new InvalidOperationException($"Invalid credentials!");
            }

            string friendUsername = data[1];

            return friendshipService.AddFriend(username, friendUsername);
        }
    }
}
