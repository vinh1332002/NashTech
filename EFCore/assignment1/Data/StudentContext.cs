using Microsoft.EntityFrameworkCore;
using assignment1.Models;

namespace assignment1.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } = null!;
    }
}