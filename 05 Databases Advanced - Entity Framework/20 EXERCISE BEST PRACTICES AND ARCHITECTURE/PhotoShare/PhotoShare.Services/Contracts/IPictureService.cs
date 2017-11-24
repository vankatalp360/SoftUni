namespace PhotoShare.Services.Contracts
{
    using PhotoShare.Models;

    public interface IPictureService
    {
        string UploadPicture(string albumName, string pictureTitle, string pictureFilePath, string username);
    }
}
