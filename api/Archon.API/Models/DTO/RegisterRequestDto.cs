using System.ComponentModel.DataAnnotations;

namespace Archon.API.Models.DTO
{
    public class RegisterRequestDto
    {
        //Dto for registering new users
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string[] Roles { get; set; }
    }
}
