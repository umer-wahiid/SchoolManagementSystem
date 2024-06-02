using SchoolManagementSystem.Domain.Entitites;

namespace SchoolManagementSystem.Services
{
  public interface IStudentService
  {
    Task<IEnumerable<Student>> GetAll();
  }
}
