using SchoolManagementSystem.Domain.Entitites;
using SchoolManagementSystem.Domain.Repositories;
using SchoolManagementSystem.Domain.UnitOfWork;
using SchoolManagementSystem.DTOs;

namespace SchoolManagementSystem.Services
{
    public class RoleService:IRoleService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        private IGenericRepository<Role> _roleRepository { get; set; }
        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _roleRepository = _unitOfWork.GenericRepository<Role>();
        }

        public async Task<IEnumerable<Role>> GetAll()
         => await _roleRepository.GetAllAsync();

        public async Task<Role> Get(int id)
              => await _roleRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Role>> Add(RoleDTO roleDto)
        {
            try
            {
                Role role = new();
                role.RoleID = roleDto.RoleID;
                role.RoleName = roleDto.RoleName;
                role.Description = roleDto.Description;

                await _roleRepository.InsertAsync(role);
                await _roleRepository.SaveAsync();
                return await _roleRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Role>> Edit(RoleDTO roleDto)
        {
            try
            {
                Role role = new();
                role.RoleID = roleDto.RoleID;
                role.RoleName = roleDto.RoleName;
                role.Description = roleDto.Description;

                _roleRepository.Update(role);
                await _roleRepository.SaveAsync();
                return await _roleRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Role>> Delete(int id)
        {
            try
            {
                Role role = await this.Get(id);
                _roleRepository.Delete(role);
                await _roleRepository.SaveAsync();
                return await _roleRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
