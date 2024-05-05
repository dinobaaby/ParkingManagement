
using Microsoft.AspNetCore.Http;
using ParkingManagement.Application.Services;

namespace ParkingManagement.Infrastucture.Repos
{
    public class UploadFileService : IUploadFileService
    {
        public FileStream GetImageAsync(string filePath)
        {
            if(File.Exists(filePath))
            {
                return new FileStream(filePath, FileMode.Open, FileAccess.Read);
            }

            return null!;
        }

        public async Task<string?> UploadFileAsync(IFormFile file, string filePath)
        {
            if(file != null && file.Length > 0)
            {
                string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Upload", filePath);
                if(!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                string fileP = Path.Combine(uploadFolder, uniqueFileName);
                using(var fileStream = new FileStream(fileP, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return $"Upload/{filePath}/{uniqueFileName}";
            }

            return "";
        }
    }
}
