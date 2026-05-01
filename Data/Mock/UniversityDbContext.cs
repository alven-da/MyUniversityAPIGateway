using Microsoft.EntityFrameworkCore;
using MyUniversityAPIGateway.Domain;

namespace MyUniversityAPIGateway.Data.Mock {
    public class UniversityDbContext(DbContextOptions<UniversityDbContext> options) : DbContext(options) {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}