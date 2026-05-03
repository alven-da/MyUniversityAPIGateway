using Microsoft.EntityFrameworkCore;
using MyUniversityAPIGateway.Data.Mock;
using MyUniversityAPIGateway.Domain;
using MyUniversityAPIGateway.Domain.Repository;

namespace Infrastructure.ExternalServices
{
    public class SubjectDbContextRepository(UniversityDbContext dbContext) : ISubjectRepository {
        private readonly UniversityDbContext _dbContext = dbContext;

        public Task<IEnumerable<Subject>> GetSubjectsAsync(int? year, string? course, int? semester) {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Subject>> GetSubjectsByStudentIDAsync(string studentId) {
            IQueryable<Subject> query = _dbContext.Subjects;
            return await query.ToListAsync();
        }
    }
}