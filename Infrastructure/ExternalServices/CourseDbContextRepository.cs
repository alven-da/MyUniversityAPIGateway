using Microsoft.EntityFrameworkCore;
using MyUniversityAPIGateway.Data.Mock;
using MyUniversityAPIGateway.Domain;
using MyUniversityAPIGateway.Domain.Repository;

namespace Infrastructure.ExternalServices
{
    public class CourseDbContextRepository(UniversityDbContext dbContext) : ICourseRepository {
        private readonly UniversityDbContext _dbContext = dbContext;

        // TODO: Implement with filters
        public async Task<IEnumerable<Course>> GetCoursesAsync(int? year, string? course, int? semester)
        {
            
            IQueryable<Course> query = _dbContext.Courses;

            return await query.ToListAsync();
        }
    }
}