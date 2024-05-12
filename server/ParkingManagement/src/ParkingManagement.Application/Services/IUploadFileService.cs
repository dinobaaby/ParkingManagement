

using Microsoft.AspNetCore.Http;

namespace ParkingManagement.Application.Services
{
    public interface IUploadFileService
    {
        Task<string?> UploadFileAsync(IFormFile file,string filePath);

        FileStream GetImageAsync(string filePath);
        Task<bool> DeleteFileAsync(string filePath);
    }
}
