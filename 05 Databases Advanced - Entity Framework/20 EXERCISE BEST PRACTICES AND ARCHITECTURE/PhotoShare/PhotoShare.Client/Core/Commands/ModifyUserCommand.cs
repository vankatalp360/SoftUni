﻿namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Commands.Contracts;
    using PhotoShare.Services.Contracts;
    using System;

    public class ModifyUserCommand:ICommand
    {
        private readonly IUserService userService;

        public ModifyUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string command, string[] data)
        {
            if (Session.User == null)
            {
                throw new ArgumentException("You should login first!");
            }

            if (data.Length < 3)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            var username = data[0];

            if (Session.User.Username != username)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var property = data[1];
            var newValue = data[2];

            return userService.ModifyUser(username, property, newValue);            
        }
    }
}
