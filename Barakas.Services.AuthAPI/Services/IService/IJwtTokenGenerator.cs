using Barakas.Services.AuthAPI.Models;

namespace Barakas.Services.AuthAPI.Services
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
