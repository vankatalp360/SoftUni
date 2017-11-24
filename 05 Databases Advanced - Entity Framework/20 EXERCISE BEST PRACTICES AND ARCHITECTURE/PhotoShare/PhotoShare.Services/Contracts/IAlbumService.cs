namespace PhotoShare.Services.Contracts
{
    using PhotoShare.Models;
    using System.Collections.Generic;

    public interface IAlbumService
    {
        string CreateAlbum(string username, string albumTitle, string BgColor, List<string> tagNames);
    }
}
