using Moq;
using MyUniversityAPIGateway.Application;
using MyUniversityAPIGateway.Domain;
using MyUniversityAPIGateway.Domain.Repository;

namespace MyUniversityAPIGateway.Tests.Application {
    public class SubjectServiceTests {
        [Fact]
        public async Task GetCurriculimByStudentID_OkWithListOfSubjects() {
            // Arrange
            var studentId = "123";
            var subjectRepositoryMock = new Mock<ISubjectRepository>();

            var subjects = new List<Subject> {
                new() { Name = "Math", Code = "MATH101", Year = 1, Course = "Science", Semester = 1 },
                new() { Name = "History", Code = "SOCGE01", Year = 1, Course = "Arts", Semester = 1 }
            };

            subjectRepositoryMock.Setup(repo => repo.GetSubjectsByStudentIDAsync(studentId))
                .ReturnsAsync(subjects);
            
            var subjectService = new SubjectService(subjectRepositoryMock.Object);

            // Act
            var result = await subjectService.GetCurriculumByStudentID(studentId);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Math", result[0].Name);
            Assert.Equal("History", result[1].Name);
        }
    }
}