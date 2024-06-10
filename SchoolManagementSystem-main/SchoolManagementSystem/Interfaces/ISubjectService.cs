using SchoolManagementSystem.Domain.Entitites;
using SchoolManagementSystem.DTOs;

namespace SchoolManagementSystem.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> Add(SubjectDTO subjectDTO);
        Task<IEnumerable<Subject>> Delete(int id);
        Task<IEnumerable<Subject>> Edit(SubjectDTO subjectDTO);
        Task<Subject> Get(int id);
        Task<IEnumerable<Subject>> GetAll();
    }
}