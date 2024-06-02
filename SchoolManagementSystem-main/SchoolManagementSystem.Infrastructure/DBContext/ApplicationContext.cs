using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entitites;
using System.Linq.Expressions;

namespace SchoolManagementSystem.Infrastructure.DBContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectResult> SubjectResults { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Permission> Permission { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                // Check if the entity type is a subclass of BaseEntity
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    // Define the IsDeleted property expression
                    var parameter = Expression.Parameter(entityType.ClrType, "entity");
                    var propertyMethodInfo = typeof(EF).GetMethod("Property").MakeGenericMethod(typeof(bool));
                    var isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant("IsDeleted"));
                    var compareExpression = Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty, Expression.Constant(false));
                    var lambda = Expression.Lambda(compareExpression, parameter);

                    // Set the query filter for this entity type
                    builder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
            }
            foreach (var ForeignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                ForeignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
