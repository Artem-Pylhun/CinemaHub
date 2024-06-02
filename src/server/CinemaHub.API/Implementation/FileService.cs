using CinemaHub.API.Interfaces;
using System.Buffers.Text;

using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Drawing.Imaging;
namespace CinemaHub.API.Implementation
{
    public class FileService : IFileService
    {
        private IWebHostEnvironment environment;
        public FileService(IWebHostEnvironment env)
        {
            environment = env;
        }
        public bool DeleteImage(string imageFileName, string directory)
        {
            try
            {
                var dir = Path.Combine(Directory.GetCurrentDirectory(), "img", directory, imageFileName);
                if (File.Exists(dir))
                {
                    File.Delete(dir);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the file from server", ex);
            }
        }

        public string SaveIFormFile(IFormFile file, string directory)
        {
            try
            {
                // Generate a unique filename
                string randomFilename = Path.GetRandomFileName() + Guid.NewGuid() + Path.GetExtension(file.FileName);
                string dir = Path.Combine(Directory.GetCurrentDirectory(), "img",directory);

                // Create the directory if it does not exist
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                string filePath = Path.Combine(dir, randomFilename);

                // Save the file to the specified path
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return randomFilename;
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, rethrow it, etc.)
                throw new Exception("An error occurred while saving the file", ex);
            }
        }



        public string SaveImage(string base64, string directory)
        {
            var bytes = Convert.FromBase64String(base64);
            try
            {
                using var stream = new MemoryStream(bytes);
                var image = Image.FromStream(stream);
                var img = new Bitmap(image);
                string randomFilename = Path.GetRandomFileName() + Guid.NewGuid() + ".jpeg";
                var dir = Path.Combine(Directory.GetCurrentDirectory(), "img" ,directory, randomFilename);
                img.Save(dir, ImageFormat.Jpeg);
                return randomFilename;
            }
            catch
            {
                throw;
            }
        }
    }
}
