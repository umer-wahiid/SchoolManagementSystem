using System.Linq.Expressions;

namespace SchoolManagementSystem.Domain.Repositories
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        Task<int> SaveAsync();
        Task<T> GetByIdAsync(int id);

        Task InsertAsync(T obj);

        IEnumerable<dynamic> GetAllListDyn();
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<dynamic>> GetAllListDynAsnc();
        T GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        void UpdateRange(List<T> obj);
        void Delete(T obj);
        void HardDelete(T obj);
        void HardDeleteRange(List<T> obj);
        void AddRange(List<T> obj);
        List<T> Where(Expression<Func<T, bool>> predicate, params string[] navigationProperties);
        void DeleteRange(IEnumerable<T> List);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        T First(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> predicate);


    }
}
