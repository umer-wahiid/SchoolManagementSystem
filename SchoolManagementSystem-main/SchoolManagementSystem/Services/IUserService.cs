using SchoolManagementSystem.Domain.Entitites;

namespace SchoolManagementSystem.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> Get(int id);
        Task<IEnumerable<User>> Add(User user);
    }
}