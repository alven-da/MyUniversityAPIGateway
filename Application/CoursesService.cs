namespace MyUniversityAPIGateway.Application;
using MyUniversityAPIGateway.Domain.Repository;
public class CoursesService(ICourseRepository courseRepository) {
    private readonly ICourseRepository _courseRepository = courseRepository;

    
}
