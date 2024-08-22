using Archon.API.Models.Domain;
using Archon.API.Models.DTO;
using Archon.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Archon.API.Controllers
{
    //controller for hosting images

    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        [HttpPost]
        [Route("Upload")]

        //[Authorize(Roles ="Writer")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
        {
            ValidateFileUpload(request);
            if (ModelState.IsValid)
            {
                var ImageDomainModel = new Image //not using automapper for explicit casting
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName,
                };
                await imageRepository.Upload(ImageDomainModel);
                var x = ImageDomainModel.Id;
                //Map to dto
                return Ok(ImageDomainModel);

            }
            return BadRequest(ModelState);
        }
        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName))) //checking for file extension
            {
                ModelState.AddModelError("file", "Unsuported file extension"); //checking for file size
            }
            if(request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File is larger than 10MB");
            }
        }

    }
}
