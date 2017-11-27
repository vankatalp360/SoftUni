namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Commands.Contracts;
    using PhotoShare.Services.Contracts;
    using System;

    public class ShareAlbumCommand : ICommand
    {
        private readonly IAlbumRoleService albumRoleService;

        public ShareAlbumCommand(IAlbumRoleService albumRoleService)
        {
            this.albumRoleService = albumRoleService;
        }
        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public string Execute(string command, params string[] data)
        {
            if (Session.User == null)
            {
                throw new ArgumentException("You should login first!");
            }            

            if (data.Length < 3)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            int albumId;
            bool result = int.TryParse(data[0], out albumId);

            if (!result)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            string username = data[1];
            string permission = data[2];
            
            return albumRoleService.ShareAlbum(albumId, username, permission , Session.User.Username);
        }
    }
}
