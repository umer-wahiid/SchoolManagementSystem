using SchoolManagementSystem.Domain.Entitites;
using SchoolManagementSystem.Domain.Repositories;
using SchoolManagementSystem.Domain.UnitOfWork;
using SchoolManagementSystem.Domain.Enums;
using SchoolManagementSystem.DTOs;

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
        {
            try
            {
                return await _studentRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Student> Get(int id)
        {
            try
            {
                return await _studentRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Student>> Add(StudentDTO studentDto)
        {
            try
            {
                Student student = new();
                student.StudentID = studentDto.StudentID;
                student.FirstName = studentDto.FirstName;
                student.LastName = studentDto.LastName;
                student.DateOfBirth = studentDto.DateOfBirth;
                student.Gender = studentDto.Gender;
                student.Address = studentDto.Address;
                student.PhoneNumber = studentDto.PhoneNumber;
                student.AdmissionDate = studentDto.AdmissionDate;
                student.UserID = studentDto.UserID;

                await _studentRepository.InsertAsync(student);
                await _studentRepository.SaveAsync();
                return await _studentRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Student>> Edit(StudentDTO studentDto)
        {
            try
            {
                var existingStudent = await _studentRepository.GetByIdAsync(studentDto.StudentID);
                if (existingStudent == null)
                    throw new KeyNotFoundException($"Student with ID {studentDto.StudentID} was not found.");

                existingStudent.FirstName = studentDto.FirstName;
                existingStudent.LastName = studentDto.LastName;
                existingStudent.DateOfBirth = studentDto.DateOfBirth;
                existingStudent.Gender = studentDto.Gender;
                existingStudent.Address = studentDto.Address;
                existingStudent.PhoneNumber = studentDto.PhoneNumber;
                existingStudent.AdmissionDate = studentDto.AdmissionDate;
                existingStudent.UserID = studentDto.UserID;

                _studentRepository.Update(existingStudent);
                await _studentRepository.SaveAsync();

                return await _studentRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Student>> Delete(int id)
        {
            try
            {
                Student student = await this.Get(id);
                if (student == null)
                    throw new KeyNotFoundException($"Student with ID {id} was not found.");

                _studentRepository.Delete(student);
                await _studentRepository.SaveAsync();
                return await _studentRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
