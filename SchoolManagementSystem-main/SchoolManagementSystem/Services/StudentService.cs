using SchoolManagementSystem.Domain.Entitites;
using SchoolManagementSystem.Domain.Repositories;
using SchoolManagementSystem.Domain.UnitOfWork;

namespace SchoolManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        private IGenericRepository<Student> _studentRepository { get; set; }
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _studentRepository = _unitOfWork.GenericRepository<Student>();
        }

        public async Task<IEnumerable<Student>> GetAll()
              => await _studentRepository.GetAllAsync();
    }
}
