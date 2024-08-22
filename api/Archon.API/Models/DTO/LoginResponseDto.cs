namespace Archon.API.Models.DTO
{
    public class LoginResponseDto
    {
        public string JwtToken { get; set; }
        public string UserName { get; set; }
        public string[] Roles { get; set; }
    }
}
