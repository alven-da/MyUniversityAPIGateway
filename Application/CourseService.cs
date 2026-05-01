namespace MyUniversityAPIGateway.Application;

using MyUniversityAPIGateway.Domain;
using MyUniversityAPIGateway.Domain.Repository;

public class CourseService(ICourseRepository courseRepository) {
    private readonly ICourseRepository _courseRepository = courseRepository;

    public virtual async Task<IEnumerable<Course>> ListAllCourses() {
        return await _courseRepository.GetCoursesAsync(null, null, null);
    }
}
