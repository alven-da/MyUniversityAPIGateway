using Microsoft.AspNetCore.Mvc;
using Moq;
using MyUniversityAPIGateway.Application;
using MyUniversityAPIGateway.Application.Dto;
using MyUniversityAPIGateway.Controller;
using MyUniversityAPIGateway.Domain.Repository;
using Xunit;


namespace MyUniversityAPIGateway.Tests.Controller {
    public class CourseControllerTests {
        [Fact]
        public async Task ListAllCourses_ReturnsOkResultWithCourses() {
            
            // Arrange
            var mockCourseRepository = new Mock<ICourseRepository>();
            var mockCourseService = new Mock<CourseService>(mockCourseRepository.Object);

            mockCourseService.Setup(service => service.ListAllCourses())
                .ReturnsAsync([
                    new() { Id = "1", Code = "BCS", Description = "Bachelor of Science in Computer Science" },
                    new() { Id = "2", Code = "BHR", Description = "Bachelor of Science in Hospitality and Restaurant Management" }
                ]);

            // Act
            var controller = new CoursesController(mockCourseService.Object);
            var result = await controller.ListAllCourses();
            var okResult = Assert.IsType<OkObjectResult>(result);

            // Asert
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}


