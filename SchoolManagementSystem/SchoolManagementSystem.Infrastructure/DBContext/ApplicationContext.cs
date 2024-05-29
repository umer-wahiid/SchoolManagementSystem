using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entitites;

namespace SchoolManagementSystem.Infrastructure.DBContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Student { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var ForeignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                ForeignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
