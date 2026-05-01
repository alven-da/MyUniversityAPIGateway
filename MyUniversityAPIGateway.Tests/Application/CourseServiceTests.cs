using Moq;
using MyUniversityAPIGateway.Application;
using MyUniversityAPIGateway.Domain;
using MyUniversityAPIGateway.Domain.Repository;
using Xunit;

namespace MyUniversityAPIGateway.Tests.Application {
    public class CourseServiceTests {
        
        [Fact]
        public async Task ListAllCourses_ReturnsOkResultWithCourses() {
            // Arrange
            var mockCourseRepository = new Mock<ICourseRepository>();

            mockCourseRepository.Setup(repo => repo.GetCoursesAsync(null, null, null))
                .ReturnsAsync(new List<Course> {
                    new() { Id = "1", Code = "COMIT01", Name = "Intro to Programming", Year = 2006, Semester = 1 },
                    new() { Id = "2", Code = "COMIT02", Name = "Programming Language I", Year = 2006, Semester = 2 }
                });

            var courseService = new CourseService(mockCourseRepository.Object);

            // Act
            var courses = await courseService.ListAllCourses();
            
            Assert.Equal("COMIT01", courses.First().Code);
        }
    }
}