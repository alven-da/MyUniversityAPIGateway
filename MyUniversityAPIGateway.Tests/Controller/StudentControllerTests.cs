using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyUniversityAPIGateway.Application;
using MyUniversityAPIGateway.Application.Dto;
using MyUniversityAPIGateway.Controller;
using MyUniversityAPIGateway.Data.Util;
using MyUniversityAPIGateway.Domain.Repository;

namespace MyUniversityAPIGateway.Tests.Controller {
    public class StudentControllerTests {
        [Fact]
        public async Task GetMyProfile_OkResult()
        {
            // Arrange
            var mockStudentRepository = new Mock<IStudentRepository>();
            var mockStudentService = new Mock<StudentService>(mockStudentRepository.Object);

            var studentId = "123";
            var expectedStudent = new StudentDto { Name = "John Doe", Email = "john.doe@example.com" };

            mockStudentService.Setup(service => service.GetStudentByID("123"))
                .ReturnsAsync(expectedStudent);

            var controller = new StudentsController(mockStudentService.Object);

            // Create a fake claim
            var claimsPrincipal = TestUtils.GetMockClaimsPrincipal(studentId);
            controller.ControllerContext = TestUtils.CreateDefaultControllerContextWithClaims(claimsPrincipal);

            // Act
            var result = await controller.GetMyProfile();
            var okResult = Assert.IsType<OkObjectResult>(result);
            
            // Assert
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetMyProfile_ReturnsUnauthorized_WhenClaimIsMissing() {
            // Arrange
            var mockStudentRepository = new Mock<IStudentRepository>();
            var mockStudentService = new Mock<StudentService>(mockStudentRepository.Object);
            var controller = new StudentsController(mockStudentService.Object);

            // TODO: to move to a helper method should be required by multiple test cases
            // Context with NO claims
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = new ClaimsPrincipal(new ClaimsIdentity()) }
            };

            // Act
            var result = await controller.GetMyProfile();

            // Assert
            Assert.IsType<UnauthorizedObjectResult>(result);
        }
    }
}