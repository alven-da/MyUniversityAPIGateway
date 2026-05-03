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
                    new() { Id = "1", Code = "BCS", Description = "Bachelor of Science in Computer Science" },
                    new() { Id = "2", Code = "BHR", Description = "Bachelor of Science in Hospitality and Restaurant Management" }
                });

            var courseService = new CourseService(mockCourseRepository.Object);

            // Act
            var courses = await courseService.ListAllCourses();
            
            Assert.Equal("BCS", courses.First().Code);
        }
    }
}