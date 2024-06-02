using SchoolManagementSystem.Domain.Entitites;
using SchoolManagementSystem.DTOs;

namespace SchoolManagementSystem.Interfaces
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permission>> Add(PermissionDTO permissionDto);
        Task<IEnumerable<Permission>> Delete(int id);
        Task<IEnumerable<Permission>> Edit(PermissionDTO permissionDto);
        Task<Permission> Get(int id);
        Task<IEnumerable<Permission>> GetAll();
    }
}