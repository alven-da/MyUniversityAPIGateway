namespace MyUniversityAPIGateway.Domain.Repository;

using MyUniversityAPIGateway.Domain;

public interface ICourseRepository {
    Task<IEnumerable<Course>> GetCoursesAsync(int? year, string? course, int? semester);
}