using System.Security.Claims;

namespace SchoolManagementSystem.Infrastructure.Authorization
{
    public interface IJwtAuthorization
    {
        string CreateToken(string username);
        IEnumerable<Claim> ValidateToken(string token);
    }
}