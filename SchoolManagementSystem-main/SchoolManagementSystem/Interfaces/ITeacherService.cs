using SchoolManagementSystem.Domain.Entitites;
using SchoolManagementSystem.DTOs;

namespace SchoolManagementSystem.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> Add(TeacherDTO studentDto);
        Task<IEnumerable<Teacher>> Delete(int id);
        Task<IEnumerable<Teacher>> Edit(TeacherDTO studentDto);
        Task<Teacher> Get(int id);
        Task<IEnumerable<Teacher>> GetAll();
    }
}