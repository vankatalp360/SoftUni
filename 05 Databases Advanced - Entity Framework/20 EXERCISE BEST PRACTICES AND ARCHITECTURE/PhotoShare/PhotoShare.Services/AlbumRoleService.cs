namespace PhotoShare.Services
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using System;
    using System.Linq;

    public class AlbumRoleService : IAlbumRoleService
    {
        private readonly PhotoShareContext context;

        public AlbumRoleService(PhotoShareContext context)
        {
            this.context = context;
        }

        public string ShareAlbum(int albumId, string username, string permission , string currentUserName)
        {
            Album album = FindAlbum(albumId);

            User userAlbumSharingdWith = FindUserAlbumSharingdWith(username);

            User currentUserSharingAlbum = FindCurrentUser(currentUserName);

            AlbumRole isCurrentUserOwner = IsCurrentUserOwner(album, currentUserSharingAlbum);

            ValidatePermission(permission, out bool isOwner, out bool isViewer);

            AlbumRole userAlbumRole = DefinceUserAlbumRole(album, userAlbumSharingdWith, currentUserSharingAlbum, isOwner, isViewer);

            album.AlbumRoles.Add(userAlbumRole);

            context.SaveChanges();

            return $"Username {username} added to album {album.Name} ({permission})";
        }

        private AlbumRole DefinceUserAlbumRole(Album album, User userAlbumSharingdWith, User currentUserSharingAlbum, bool isOwner, bool isViewer)
        {
            AlbumRole userAlbumRole = FindExistingRole(album, userAlbumSharingdWith, isOwner);

            userAlbumRole = DefineNewRole(album, userAlbumSharingdWith, currentUserSharingAlbum, isOwner, isViewer, userAlbumRole);

            return userAlbumRole;
        }

        private static AlbumRole DefineNewRole(Album album, User userAlbumSharingdWith, User currentUserSharingAlbum, bool isOwner, bool isViewer, AlbumRole userAlbumRole)
        {
            if (userAlbumRole == null)
            {
                userAlbumRole = new AlbumRole
                {
                    Album = album,

                    User = userAlbumSharingdWith
                };

                if (isOwner)
                {
                    if (userAlbumSharingdWith != currentUserSharingAlbum)
                    {
                        throw new InvalidOperationException($"Invalid credentials!");
                    }
                    userAlbumRole.Role = Role.Owner;
                }
                else if (isViewer)
                {
                    if (userAlbumSharingdWith == currentUserSharingAlbum)
                    {
                        throw new InvalidOperationException($"Invalid credentials!");
                    }

                    userAlbumRole.Role = Role.Viewer;
                }
            }

            return userAlbumRole;
        }

        private AlbumRole FindExistingRole(Album album, User userAlbumSharingdWith, bool isOwner)
        {
            AlbumRole userAlbumRole;

            if (isOwner)
            {
                userAlbumRole = SelectUserAlbumOwnerRole(album, userAlbumSharingdWith);
            }
            else
            {
                userAlbumRole = ExistsUserAlbumViewerRole(album, userAlbumSharingdWith);
            }

            return userAlbumRole;
        }

        private AlbumRole ExistsUserAlbumViewerRole(Album album, User userAlbumSharingdWith)
        {
            AlbumRole existsUserAlbumRole = userAlbumSharingdWith.AlbumRoles.SingleOrDefault(ar => ar.Album == album && ar.Role == Role.Viewer);

            return existsUserAlbumRole;
        }

        private AlbumRole SelectUserAlbumOwnerRole(Album album, User userAlbumSharingdWith)
        {
            AlbumRole existsUserAlbumRole = userAlbumSharingdWith.AlbumRoles.SingleOrDefault(ar => ar.Album == album && ar.Role==Role.Owner);

            return existsUserAlbumRole;
        }

        private static AlbumRole IsCurrentUserOwner(Album album, User currentUserSharingAlbum)
        {
            AlbumRole isUserOwner = currentUserSharingAlbum.AlbumRoles.SingleOrDefault(ar => ar.Album == album && ar.Role == Role.Owner);

            if (isUserOwner == null)
            {
                throw new InvalidOperationException($"Invalid credentials!");
            }

            return isUserOwner;
        }

        private User FindCurrentUser(string currentUserName)
        {
            var userSharingAlbum = context.Users.SingleOrDefault(u => u.Username == currentUserName);

            if (userSharingAlbum == null)
            {
                throw new InvalidOperationException($"Invalid credentials!");
            }

            return userSharingAlbum;
        }

        private User FindUserAlbumSharingdWith(string username)
        {
            var userAlbumSharedWith = context.Users.SingleOrDefault(u => u.Username == username);

            if (userAlbumSharedWith == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            return userAlbumSharedWith;
        }

        private Album FindAlbum(int albumId)
        {
            var album = context.Albums.SingleOrDefault(a => a.Id == albumId);

            if (album == null)
            {
                throw new ArgumentException($"Album {albumId} not found!");
            }

            return album;
        }

        private static void ValidatePermission(string permission, out bool isOwner, out bool isViewer)
        {
            isOwner = String.Equals(permission, Role.Owner.ToString(), StringComparison.InvariantCultureIgnoreCase);
            isViewer = String.Equals(permission, Role.Viewer.ToString(), StringComparison.InvariantCultureIgnoreCase);
            if (!isOwner && !isViewer)
            {
                throw new ArgumentException("Permission must be either “Owner” or “Viewer”!");
            }
        }
    }
}
