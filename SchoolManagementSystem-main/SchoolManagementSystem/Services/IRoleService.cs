using SchoolManagementSystem.Domain.Entitites;
using SchoolManagementSystem.DTOs;

namespace SchoolManagementSystem.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> Add(RoleDTO role);
        Task<IEnumerable<Role>> Delete(int id);
        Task<IEnumerable<Role>> Edit(RoleDTO role);
        Task<Role> Get(int id);
        Task<IEnumerable<Role>> GetAll();
    }
}