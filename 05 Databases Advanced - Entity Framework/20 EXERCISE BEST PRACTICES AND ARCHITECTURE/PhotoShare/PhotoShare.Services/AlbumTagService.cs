namespace PhotoShare.Services
{
    using System;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class AlbumTagService : IAlbumTagService
    {
        private readonly PhotoShareContext context;

        public AlbumTagService(PhotoShareContext context)
        {
            this.context = context;
        }

        public string AddTagTo(string albumName, string tagName, int userId)
        {
            Album album = FindAlbum(albumName);

            Tag tag = FindTag(tagName);

            User user = FindUser(userId);

            ValideteUserRoleToAlbum(album, user);

            var albumTag = context.AlbumTags.SingleOrDefault(at => at.Album == album && at.Tag == tag);

            if (albumTag == null)
            {
                albumTag = new AlbumTag
                {
                    Album = album,
                    Tag = tag
                };
            }            

            album.AlbumTags.Add(albumTag);

            tag.AlbumTags.Add(albumTag);

            context.SaveChanges();

            return $"Tag {tagName} added to {albumName}!";
        }

        private static void ValideteUserRoleToAlbum(Album album, User user)
        {
            var userRole = user.AlbumRoles.SingleOrDefault(ar => ar.Album == album);

            if (userRole == null || !userRole.Role.Equals(Role.Owner))
            {
                throw new InvalidOperationException($"Invalid credentials!");
            }
        }

        private User FindUser(int userId)
        {
            var user = context.Users.SingleOrDefault(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException($"Invalid credentials!");
            }

            return user;
        }

        private Tag FindTag(string tagName)
        {
            var tag = context.Tags.SingleOrDefault(t => t.Name == "#" + tagName);

            if (tag == null)
            {
                throw new ArgumentException("Either tag or album do not exist!");
            }

            return tag;
        }

        private Album FindAlbum(string albumName)
        {
            var album = context.Albums.SingleOrDefault(a => a.Name == albumName);

            if (album == null)
            {
                throw new ArgumentException("Either tag or album do not exist!");
            }

            return album;
        }
    }
}
