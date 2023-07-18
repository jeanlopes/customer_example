using Microsoft.AspNetCore.Http;

namespace CustomerExample.Infrastructure.Utilities
{
    public static class FileHelper
    {
        public static string SaveLogoAndGetPath(IFormFile logo)
        {
            if (logo != null && logo.Length > 0)
            {
                // Define the directory path where the logo files will be stored
                var logosDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Logos");

                // Create the directory if it doesn't exist
                if (!Directory.Exists(logosDirectory))
                {
                    Directory.CreateDirectory(logosDirectory);
                }

                // Generate a unique filename for the logo
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(logo.FileName);
                var filePath = Path.Combine("Logos", uniqueFileName);
                var savePath = Path.Combine("wwwroot\\Logos", uniqueFileName);

                // Save the logo file to the specified path
                using (var fileStream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), savePath), FileMode.Create))
                {
                    logo.CopyTo(fileStream);
                }

                // Return the saved logo file path
                return filePath;
            }

            throw new Exception("Logo file is null");
        }

    }
}
