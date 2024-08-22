using Microsoft.AspNetCore.Identity;

namespace Archon.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
