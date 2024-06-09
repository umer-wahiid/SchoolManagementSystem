using SchoolManagementSystem.Domain.Entitites;
using SchoolManagementSystem.Domain.Repositories;
using SchoolManagementSystem.Domain.UnitOfWork;
using SchoolManagementSystem.Domain.Enums;
using SchoolManagementSystem.DTOs;
using SchoolManagementSystem.Interfaces;

namespace SchoolManagementSystem.Services
{
    public class TeacherService :  ITeacherService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        private IGenericRepository<Teacher> _teacherRepository { get; set; }

        public TeacherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _teacherRepository = _unitOfWork.GenericRepository<Teacher>();
        }

        public async Task<IEnumerable<Teacher>> GetAll()
        {
            try
            {
                return await _teacherRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Teacher> Get(int id)
        {
            try
            {
                return await _teacherRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Teacher>> Add(TeacherDTO teacherDto)
        {
            try
            {
                Teacher Teacher = new();
                Teacher.TeacherID = teacherDto.TeacherID;
                Teacher.FirstName = teacherDto.FirstName;
                Teacher.LastName = teacherDto.LastName;
                Teacher.DateOfBirth = teacherDto.DateOfBirth;
                Teacher.Gender = teacherDto.Gender;
                Teacher.Address = teacherDto.Address;
                Teacher.PhoneNumber = teacherDto.PhoneNumber;
                Teacher.HireDate = teacherDto.HireDate;
                Teacher.Specialization = teacherDto.Specialization;
                Teacher.UserID = teacherDto.UserID;

                await _teacherRepository.InsertAsync(Teacher);
                await _unitOfWork.SaveAsync();
                return await _teacherRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Teacher>> Edit(TeacherDTO teacherDto)
        {
            try
            {
                var existingTeacher = await _teacherRepository.GetByIdAsync(teacherDto.TeacherID);
                if (existingTeacher == null)
                    throw new KeyNotFoundException($"Teacher with ID {teacherDto.TeacherID} was not found.");

                existingTeacher.FirstName = teacherDto.FirstName;
                existingTeacher.LastName = teacherDto.LastName;
                existingTeacher.DateOfBirth = teacherDto.DateOfBirth;
                existingTeacher.Gender = teacherDto.Gender;
                existingTeacher.Address = teacherDto.Address;
                existingTeacher.PhoneNumber = teacherDto.PhoneNumber;
                existingTeacher.HireDate = teacherDto.HireDate;
                existingTeacher.Specialization = teacherDto.Specialization;
                existingTeacher.UserID = teacherDto.UserID;

                _teacherRepository.Update(existingTeacher);
                await _unitOfWork.SaveAsync();

                return await _teacherRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Teacher>> Delete(int id)
        {
            try
            {
                Teacher teacher = await this.Get(id);
                if (teacher == null)
                    throw new KeyNotFoundException($"Teacher with ID {id} was not found.");

                _teacherRepository.Delete(teacher);
                await _unitOfWork.SaveAsync();
                return await _teacherRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
