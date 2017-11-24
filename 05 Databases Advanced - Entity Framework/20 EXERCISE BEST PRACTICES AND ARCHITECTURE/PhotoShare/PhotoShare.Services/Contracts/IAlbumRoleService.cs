namespace PhotoShare.Services.Contracts
{
    using PhotoShare.Models;

    public interface IAlbumRoleService
    {
        string ShareAlbum(int albumId, string username, string permission);
    }
}
