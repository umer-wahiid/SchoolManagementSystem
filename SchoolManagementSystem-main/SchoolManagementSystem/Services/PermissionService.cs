using SchoolManagementSystem.Domain.Entitites;
using SchoolManagementSystem.Domain.Repositories;
using SchoolManagementSystem.Domain.UnitOfWork;
using SchoolManagementSystem.DTOs;
using SchoolManagementSystem.Interfaces;

namespace SchoolManagementSystem.Services
{
    public class PermissionService : IPermissionService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        private IGenericRepository<Permission> _permissionRepository { get; set; }

        public PermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _permissionRepository = _unitOfWork.GenericRepository<Permission>();
        }

        public async Task<IEnumerable<Permission>> GetAll()
            => await _permissionRepository.GetAllAsync();

        public async Task<Permission> Get(int id)
            => await _permissionRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Permission>> Add(PermissionDTO permissionDto)
        {
            try
            {
                Permission permission = new();
                permission.PermissionID = permissionDto.PermissionID;
                permission.RoleID = permissionDto.RoleID;
                permission.PageID = permissionDto.PageID;
                permission.Create = permissionDto.Create;
                permission.Delete = permissionDto.Delete;
                permission.Update = permissionDto.Update;
                permission.View = permissionDto.View;

                await _permissionRepository.InsertAsync(permission);
                await _permissionRepository.SaveAsync();
                return await _permissionRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Permission>> Edit(PermissionDTO permissionDto)
        {
            try
            {
                var existingPermission = await _permissionRepository.GetByIdAsync(permissionDto.PermissionID);
                if (existingPermission == null)
                    throw new KeyNotFoundException($"Permission with ID {permissionDto.PermissionID} was not found.");

                existingPermission.RoleID = permissionDto.RoleID;
                existingPermission.PageID = permissionDto.PageID;
                existingPermission.Create = permissionDto.Create;
                existingPermission.Delete = permissionDto.Delete;
                existingPermission.Update = permissionDto.Update;
                existingPermission.View = permissionDto.View;

                _permissionRepository.Update(existingPermission);
                await _permissionRepository.SaveAsync();

                return await _permissionRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Permission>> Delete(int id)
        {
            try
            {
                Permission permission = await this.Get(id);
                if (permission == null)
                    throw new KeyNotFoundException($"Permission with ID {id} was not found.");

                _permissionRepository.Delete(permission);
                await _permissionRepository.SaveAsync();
                return await _permissionRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
