using SchoolManagementSystem.Domain.Entitites;
using SchoolManagementSystem.DTOs;
using System.Security.Claims;

namespace SchoolManagementSystem.Interfaces
{
    public interface IAuthService
    {
        string Authenticate(OAuth auth);
        IEnumerable<Claim> ValidateToken(string token);
    }
}