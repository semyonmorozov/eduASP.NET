using Microsoft.EntityFrameworkCore;
using StudentGroup.Models;

namespace StudentGroup.StudentsDB
{
    public class StudentContext :DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
            
        }

        public DbSet<StudentModel> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentModel>().HasKey(x => x.StudentCardNumber);
        }
    }
}