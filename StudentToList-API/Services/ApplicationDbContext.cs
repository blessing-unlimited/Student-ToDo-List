using Microsoft.EntityFrameworkCore;
using StudentToList_API.Models;

namespace StudentToList_API.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        public DbSet<Tasks> StudentTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            object value = modelBuilder.Entity<Tasks>()
                .HasOne<Student>()
                .WithMany()
                .HasForeignKey(t => t.StudentId);
        }
    }
}
