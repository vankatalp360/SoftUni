namespace PhotoShare.Services
{
    using System.Collections.Generic;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;
    using PhotoShare.Data;
    using System.Linq;
    using System;

    public class AlbumService : IAlbumService
    {
        private readonly PhotoShareContext context;

        public AlbumService(PhotoShareContext context)
        {
            this.context = context;
        }

        public string CreateAlbum(string username, string albumTitle, string BgColor, List<string> tagNames)
        {
            User user = FindUser(username);

            Album album = FindAlbum(albumTitle);

            Color color = FindColor(BgColor);

            List<AlbumTag> albumTags = CreateAlbumTags(tagNames, album);

            Album currentAlbum = CreateAlbum(albumTitle, album, color, albumTags);            

            context.SaveChanges();
            
            AlbumRole albumRole = new AlbumRole()
            {
                Album = currentAlbum,
                User=user,
                Role=Role.Owner
            };

            user.AlbumRoles.Add(albumRole);

            context.SaveChanges();

            return $"Album {albumTitle} successfully created!";
        }

        private Album CreateAlbum(string albumTitle, Album album, Color color, List<AlbumTag> albumTags)
        {
            album = new Album
            {
                Name = albumTitle,
                BackgroundColor = color,
                AlbumTags= albumTags
            };

            context.Albums.Add(album);

            context.SaveChanges();

            return album;
        }

        private List<AlbumTag> CreateAlbumTags(List<string> tagNames, Album album)
        {
            List<Tag> tags = FindTagList(tagNames);

            var albumTags = new List<AlbumTag>();

            foreach (var tag in tags)
            {
                var albumTag = new AlbumTag()
                {
                    Tag = tag,
                    Album = album
                };

                albumTags.Add(albumTag);
            }

            return albumTags;
        }

        private List<Tag> FindTagList(List<string> tagNames)
        {
            List<Tag> tags = context.Tags.Where(t => tagNames.Contains(t.Name.Substring(1))).ToList();

            //if (tags.Count == 0)
            //{
            //    throw new ArgumentException("Invalid tags!");
            //}

            return tags;
        }

        private static Color FindColor(string BgColor)
        {
            if (!Enum.IsDefined(typeof(Color), BgColor))
                throw new ArgumentException($"Color {BgColor} not found!");

            var color = Enum.Parse<Color>(BgColor);

            return color;
        }

        private Album FindAlbum(string albumTitle)
        {
            var album = context.Albums.SingleOrDefault(a => a.Name == albumTitle);

            if (album != null)
            {
                throw new ArgumentException($"Album {albumTitle} exists!");
            }

            return album;
        }

        private User FindUser(string username)
        {
            var user = context.Users.SingleOrDefault(u => u.Username == username);

            if (user == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            return user;
        }
    }
}
