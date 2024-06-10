using SchoolManagementSystem.Domain.Entitites;
using SchoolManagementSystem.Domain.Repositories;
using SchoolManagementSystem.Domain.UnitOfWork;
using SchoolManagementSystem.DTOs;
using SchoolManagementSystem.Interfaces;

namespace SchoolManagementSystem.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Subject> _subjectRepository;

        public SubjectService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _subjectRepository = unitOfWork.GenericRepository<Subject>();
        }
        public async Task<IEnumerable<Subject>> GetAll()
             => await _subjectRepository.GetAllAsync();

        public async Task<Subject> Get(int id)
        {
            return await _subjectRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Subject>> Add(SubjectDTO subjectDTO)
        {
            try
            {
                Subject subject = new();
                subject.SubjectID = subjectDTO.SubjectID;
                subject.SubjectName = subjectDTO.Name;
                subject.Description = subjectDTO.Description;

                await _subjectRepository.InsertAsync(subject);
                await _unitOfWork.SaveAsync();
                return await _subjectRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Subject>> Edit(SubjectDTO subjectDTO)
        {
            try
            {
                var existingSubject = await _subjectRepository.GetByIdAsync(subjectDTO.SubjectID);
                if (existingSubject == null)
                {
                    throw new KeyNotFoundException($"Subject with ID {subjectDTO.SubjectID} was not found.");
                }

                existingSubject.SubjectName = subjectDTO.Name;
                existingSubject.Description = subjectDTO.Description;

                _subjectRepository.Update(existingSubject);
                await _unitOfWork.SaveAsync();

                return await this.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Subject>> Delete(int id)
        {
            try
            {
                Subject subject = await this.Get(id);
                if (subject == null)
                {
                    throw new KeyNotFoundException($"subject with ID {id} was not found.");
                }
                _subjectRepository.Delete(subject);
                await _unitOfWork.SaveAsync();
                return await this.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}