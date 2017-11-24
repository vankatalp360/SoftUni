namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Commands.Contracts;
    using System;

    class UserDetailsCommand : ICommand
    {
        public string Execute(string command, params string[] data)
        {
            if (data.Length != 2)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            if (Session.User == null)
            {
                return "You are not logged in!";
            }

            var currentUser = Session.User.Username;

            return $"{currentUser}";
        }
    }
}
