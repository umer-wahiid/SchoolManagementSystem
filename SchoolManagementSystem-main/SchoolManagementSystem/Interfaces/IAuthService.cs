using SchoolManagementSystem.Domain.Entitites;
using SchoolManagementSystem.DTOs;

namespace SchoolManagementSystem.Interfaces
{
    public interface IAuthService
    {
        User Authenticate(OAuth auth);
    }
}