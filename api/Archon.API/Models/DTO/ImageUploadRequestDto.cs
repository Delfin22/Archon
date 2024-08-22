using System.ComponentModel.DataAnnotations;

namespace Archon.API.Models.DTO
{
    public class ImageUploadRequestDto
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }

    }
}
