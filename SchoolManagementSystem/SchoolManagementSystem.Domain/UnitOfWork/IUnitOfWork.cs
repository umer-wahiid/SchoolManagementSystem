using Microsoft.EntityFrameworkCore.Storage;

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