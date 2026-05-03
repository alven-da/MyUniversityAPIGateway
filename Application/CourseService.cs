

using MyUniversityAPIGateway.Application.Dto;
using MyUniversityAPIGateway.Domain;
using MyUniversityAPIGateway.Domain.Repository;

namespace MyUniversityAPIGateway.Application {
    public class CourseService(ICourseRepository courseRepository) {
        private readonly ICourseRepository _courseRepository = courseRepository;

        private CourseDto ToDto(Course course) {
            return new CourseDto {
                Id = course.Id,
                Description = course.Description,
                Code = course.Code,
            };
        }

        public virtual async Task<IEnumerable<CourseDto>> ListAllCourses() {
            var courses = await _courseRepository.GetCoursesAsync(null, null, null);
            return courses.Select(ToDto);
        }
    }
}
