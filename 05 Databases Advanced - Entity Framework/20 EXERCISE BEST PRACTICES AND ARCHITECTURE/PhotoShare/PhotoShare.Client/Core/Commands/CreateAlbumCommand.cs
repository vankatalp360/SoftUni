﻿namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Commands.Contracts;
    using PhotoShare.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CreateAlbumCommand : ICommand
    {
        private readonly IAlbumService albumService;

        public CreateAlbumCommand(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string command , params string[] data)
        {
            if (Session.User == null)
            {
                throw new ArgumentException("You should login first!");
            }

            if (data.Length < 3)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            string username = data[0];

            if (username != Session.User.Username)
            {
                throw new InvalidOperationException($"Invalid credentials!");
            }

            string albumTitle = data[1];
            string BgColor=data[2];
            List<string> tagNames = data.Skip(3).ToList();

            return albumService.CreateAlbum(username, albumTitle, BgColor, tagNames);
        }
    }
}
