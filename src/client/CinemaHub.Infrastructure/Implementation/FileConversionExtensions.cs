using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub.Infrastructure.Implementation
{
    public static class FileConversionExtensions
    {
        public static async Task<string> ToBase64Async(this IBrowserFile file)
        {
            try
            {
                using (var readStream = file.OpenReadStream())
                using (var memoryStream = new MemoryStream())
                {
                    await readStream.CopyToAsync(memoryStream);
                    var bytes = memoryStream.ToArray();
                    return Convert.ToBase64String(bytes);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
