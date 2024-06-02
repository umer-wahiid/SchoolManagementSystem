using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entitites;
using SchoolManagementSystem.Domain.Repositories;
using SchoolManagementSystem.Infrastructure.DBContext;
using System.Linq.Expressions;

namespace SchoolManagementSystem.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public ApplicationContext _context = null;
        public DbSet<T> DbSet = null;
        public bool Disposed = false;
        public GenericRepository(ApplicationContext dbContext)
        {
            _context = dbContext;
            DbSet = _context.Set<T>();
        }

        public void AddRange(List<T> obj)
        {
            _context.Set<T>().AddRange(obj);
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            var query = _context.Set<T>().AsQueryable();
            return query.Any(predicate);
        }

        public void Delete(T obj)
        {
            if (obj is BaseEntity baseEntity)
            {
                baseEntity.IsDeleted = true;
                baseEntity.ModifiedAt = DateTime.UtcNow;
                baseEntity.ModifiedBy = ""; 
                DbSet.Attach(obj);
                _context.Entry(obj).State = EntityState.Modified;
            }
        }

        public void DeleteRange(IEnumerable<T> list)
        {
            foreach (var item in list)
                Delete(item);
        }

        protected virtual void Dispose(bool Disposing)
        {
            if (!Disposed)
            {
                if (Disposing)
                {
                    _context.Dispose();
                }
            }
            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            T item;
            var query = _context.Set<T>().AsQueryable();
            item = query.First(predicate);
            return item;
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            T item;
            var query = _context.Set<T>().AsQueryable();
            item = query.FirstOrDefault(predicate);
            return item;
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<dynamic>> GetAllListDynAsnc()
        {
            return await DbSet.ToListAsync<dynamic>();
        }

        public IEnumerable<dynamic> GetAllListDyn()
        {
            return DbSet.ToList<dynamic>();
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public void HardDelete(T obj)
        {
            DbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Deleted;
        }

        public void HardDeleteRange(List<T> obj)
        {
            DbSet.AttachRange(obj);
            obj.ToList().ForEach(e =>
            {
                _context.Entry(e).State = EntityState.Deleted;
            });
        }

        public void Insert(T obj)
        {
            if (obj is BaseEntity baseEntity)
            {
                baseEntity.CreatedAt = DateTime.UtcNow;
                DbSet.Add(obj);
            }
        }

        public async Task InsertAsync(T obj)
        {
            if (obj is BaseEntity baseEntity)
                baseEntity.CreatedAt = DateTime.UtcNow;
            await DbSet.AddAsync(obj);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(T obj)
        {
            var entry = _context.Entry(obj);
            if (entry.State == EntityState.Detached)
            {
                DbSet.Attach(obj);
            }
            if (obj is BaseEntity baseEntity)
                baseEntity.ModifiedAt = DateTime.UtcNow;
            entry.State = EntityState.Modified;
        }

        public void UpdateRange(List<T> obj)
        {
            DbSet.AttachRange(obj);
            obj.ToList().ForEach(e =>
            {
                _context.Entry(e).State = EntityState.Modified;
            });
        }

        public List<T> Where(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        {
            List<T> list;
            var query = _context.Set<T>().AsQueryable();
            foreach (string navigationProperty in navigationProperties)
                query = query.Include(navigationProperty);
            list = query.Where(predicate).ToList<T>();
            return list;
        }
    }
}
