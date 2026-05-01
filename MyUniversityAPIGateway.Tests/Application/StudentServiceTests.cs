using Moq;
using MyUniversityAPIGateway.Application;
using MyUniversityAPIGateway.Domain;
using MyUniversityAPIGateway.Domain.Repository;

namespace MyUniversityAPIGateway.Tests.Application {
    public class StudentServiceTests {
        [Fact]
        public async Task GetStudentByID_ReturnsStudentDto() {
            // Arrange
            var mockStudentRepository = new Mock<IStudentRepository>();

            mockStudentRepository.Setup(repo => repo.GetProfileAsync("123"))
                .ReturnsAsync(new Student { Id = "123", Name = "John Doe", Email = "john.doe@example.com" });

            var studentService = new StudentService(mockStudentRepository.Object);

            // Act
            var student = await studentService.GetStudentByID("123");

            Assert.Equal("123", student.Id);
            Assert.Equal("John Doe", student.Name);
        }
    }
}