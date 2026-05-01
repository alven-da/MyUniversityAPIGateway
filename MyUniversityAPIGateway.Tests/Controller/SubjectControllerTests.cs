using Microsoft.AspNetCore.Mvc;
using Moq;
using MyUniversityAPIGateway.Application;
using MyUniversityAPIGateway.Application.Dto;
using MyUniversityAPIGateway.Controller;
using MyUniversityAPIGateway.Data.Util;
using MyUniversityAPIGateway.Domain;
using MyUniversityAPIGateway.Domain.Repository;

namespace MyUniversityAPIGateway.Tests.Controller {

    
    public class SubjectControllerTests {
        [Fact]
        public async Task GetCurriculum_ReturnsOkResult_WithListOfSubjects() {
            // Arrange
            var studentId = "123";
            var subjectRepositoryMock = new Mock<ISubjectRepository>();

            var subjects = new List<Subject> {
                new() { Name = "Math", Code = "MATH101", Year = 1, Course = "Science", Semester = 1 },
                new() { Name = "History", Code = "HIST101", Year = 1, Course = "Arts", Semester = 1 }
            };

            subjectRepositoryMock.Setup(repo => repo.GetSubjectsByStudentIDAsync(studentId))
                .ReturnsAsync(subjects);
            
            var subjectService = new Mock<SubjectService>(subjectRepositoryMock.Object);;

            // Act
            var subjectController = new SubjectsController(subjectService.Object);

            var claimsPrincipal = TestUtils.GetMockClaimsPrincipal(studentId);
            subjectController.ControllerContext = TestUtils.CreateDefaultControllerContextWithClaims(claimsPrincipal);

            var result = await subjectController.GetCurriculum();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnSubjects = Assert.IsType<List<SubjectDto>>(okResult.Value);

            Assert.Equal(2, returnSubjects.Count);
        }
    }
}