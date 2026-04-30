namespace MyUniversityAPIGateway.Domain.Repository;

using MyUniversityAPIGateway.Domain;

public interface ISubjectRepository {
    Task<IEnumerable<Subject>> GetSubjectsAsync(int? year, string? course, int? semester);
}