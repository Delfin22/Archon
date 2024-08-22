using System.ComponentModel.DataAnnotations;

namespace Archon.API.Models.DTO
{
    public class LoginRequestDto
    {
        //DTO for login users
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } 
    }
}
