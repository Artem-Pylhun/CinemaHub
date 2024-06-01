namespace CinemaHub.API.Interfaces
{
    public interface IFileService
    {
        public string SaveImage(string imageFile, string directory);
        public string SaveIFormFile(IFormFile imageFile, string directory);
        public bool DeleteImage(string imageFileName, string directory);
    }
}
