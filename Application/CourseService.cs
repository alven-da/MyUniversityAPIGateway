

using MyUniversityAPIGateway.Application.Dto;
using MyUniversityAPIGateway.Domain;
using MyUniversityAPIGateway.Domain.Repository;

namespace MyUniversityAPIGateway.Application {
    public class CourseService(ICourseRepository courseRepository) {
        private readonly ICourseRepository _courseRepository = courseRepository;

        private CourseDto ToDto(Course course) {
            return new CourseDto {
                Name = course.Name,
                Description = course.Description,
                Code = course.Code,
                Semester = course.Semester,
                Year = course.Year
            };
        }

        public virtual async Task<IEnumerable<CourseDto>> ListAllCourses() {
            var courses = await _courseRepository.GetCoursesAsync(null, null, null);
            return courses.Select(ToDto);
        }
    }
}
