using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Application.Services;

namespace ParkingManagement.Webserver.Controllers
{
    [Route("api/upload")]
    [ApiController]
    public class UploadFileController : Controller
    {
        private readonly IUploadFileService _uploadFileService;
        public UploadFileController(IUploadFileService uploadFileService)
        {
            _uploadFileService = uploadFileService;
        }


        [HttpPost]
        [Route("file")]
        public async Task<IActionResult> UploadFile([FromForm] string Folder, IFormFile file)
        {
            var result = await _uploadFileService.UploadFileAsync(file, Folder);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetImage(string filePath)
        {
            var result = _uploadFileService.GetImageAsync(filePath);
            if (result != null)
            {
                return File(result, "image/jpeg");
            }

            return BadRequest();
        }
    }
}
