namespace MyUniversityAPIGateway.Domain.Repository;

public interface IStudentRepository {
    Task<Student> GetProfileAsync(string studentId);
    Task<Curriculum> GetCurriculumAsync(string studentId);
}


