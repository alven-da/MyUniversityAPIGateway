using Microsoft.AspNetCore.Mvc;
using Moq;
using MyUniversityAPIGateway.Application;
using MyUniversityAPIGateway.Controller;
using MyUniversityAPIGateway.Domain;
using Xunit;


namespace MyUniversityAPIGateway.Tests;

public class CourseControllerTests {
    [Fact]
    public async Task ListAllCourses_ReturnsOkResultWithCourses() {
        var mockCourseService = new Mock<CourseService>();

        mockCourseService.Setup(service => service.ListAllCourses())
            .ReturnsAsync(new List<Course> {
                new() { Id = "1", Code = "COMIT01", Name = "Intro to Programming", Year = 2006, Semester = 1 },
                new() { Id = "2", Code = "COMIT02", Name = "Programming Language I", Year = 2006, Semester = 2 }
            });

        var controller = new CoursesController(mockCourseService.Object);
        var result = await controller.ListAllCourses();
        var okResult = Assert.IsType<OkObjectResult>(result);

        Assert.Equal(200, okResult.StatusCode);
    }
}
