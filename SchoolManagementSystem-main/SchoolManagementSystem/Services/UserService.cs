using SchoolManagementSystem.Domain.Entitites;
using SchoolManagementSystem.Domain.Repositories;
using SchoolManagementSystem.Domain.UnitOfWork;
using SchoolManagementSystem.DTOs;

namespace SchoolManagementSystem.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        private IGenericRepository<User> _userRepository { get; set; }
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GenericRepository<User>();
        }

        public async Task<IEnumerable<User>> GetAll()
              => await _userRepository.GetAllAsync();

        public async Task<User> Get(int id)
              => await _userRepository.GetByIdAsync(id);

        public async Task<IEnumerable<User>> Add(UserDTO userDto)
        {
            try
            {
                User user = new();
                user.RoleID = userDto.RoleID;
                user.Username = userDto.Username;
                user.Password = userDto.Password;
                user.Email = userDto.Email;

                await _userRepository.InsertAsync(user);            
                await _userRepository.SaveAsync();            
                return await _userRepository.GetAllAsync();
            }
            catch (Exception){
                throw;
            }
        }
    }
}
