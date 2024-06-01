using SchoolManagementSystem.Domain.Entitites;
using SchoolManagementSystem.Domain.Repositories;
using SchoolManagementSystem.Domain.UnitOfWork;

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

        public async Task<IEnumerable<User>> Add(User user)
        {
            try
            {
                await _userRepository.InsertAsync(user);            
                return await _userRepository.GetAllAsync();
            }
            catch (Exception){
                throw;
            }
        }
    }
}
