using SchoolManagementSystem.Domain.Entitites;
using SchoolManagementSystem.DTOs;

namespace SchoolManagementSystem.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> Add(StudentDTO studentDto);
        Task<IEnumerable<Student>> Delete(int id);
        Task<IEnumerable<Student>> Edit(StudentDTO studentDto);
        Task<Student> Get(int id);
        Task<IEnumerable<Student>> GetAll();
    }
}
