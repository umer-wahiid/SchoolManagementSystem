using Microsoft.EntityFrameworkCore.Storage;
using SchoolManagementSystem.Domain.Repositories;

namespace SchoolManagementSystem.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDbContextTransaction Begin();
        void Commit();
        void Dispose();
        IGenericRepository<T> GenericRepository<T>() where T : class;
        void Rollback();
        int Save();
        Task<int> SaveAsync();
    }
}