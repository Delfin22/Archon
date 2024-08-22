using System.ComponentModel.DataAnnotations;

namespace Archon.API.Models.DTO
{
    public class CreateItemDto
    {
        //DTO for receiving data from clients with validation
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        public string? ItemImgUrl { get; set; }
        [Required]
        [Range(1,1000000000)]
        public double Price { get; set; }
        [Required]
        public bool IsAvaliable { get; set; }
    }
}
