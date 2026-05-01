using MyUniversityAPIGateway.Domain;
using MyUniversityAPIGateway.Domain.Repository;

namespace MyUniversityAPIGateway.Infrastructure.ExternalServices;

public class HttpCourseRepository(HttpClient httpClient) : ICourseRepository
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<IEnumerable<Course>> GetCoursesAsync(int? year, string? course, int? semester)
    {
        // You would call your external service here
        // For now, returning empty list - implement your API call
        return await Task.FromResult(Enumerable.Empty<Course>());
    }
}