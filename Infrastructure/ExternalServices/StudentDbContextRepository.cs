using MyUniversityAPIGateway.Data.Mock;
using MyUniversityAPIGateway.Domain;
using MyUniversityAPIGateway.Domain.Repository;

namespace Infrastructure.ExternalServices
{
    public class StudentDbContextRepository(UniversityDbContext dbContext) : IStudentRepository {
        private readonly UniversityDbContext _dbContext = dbContext;

        public Task<Curriculum> GetCurriculumAsync(string studentId) {
            throw new NotImplementedException();
        }

        public async Task<Student> GetProfileAsync(string studentId) {
            return _dbContext.Students.Find(studentId);
        }

    }
}