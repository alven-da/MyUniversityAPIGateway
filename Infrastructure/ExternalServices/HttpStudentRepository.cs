using MyUniversityAPIGateway.Domain;
using MyUniversityAPIGateway.Domain.Repository;

public class HttpStudentRepository(HttpClient httpClient) : IStudentRepository {
    private readonly HttpClient _httpClient = httpClient;

    public async Task<Student> GetProfileAsync(string studentId) {
        // You would call your external service here
        return await _httpClient.GetFromJsonAsync<Student>($"/api/students/{studentId}");
    }

    public async Task<Curriculum> GetCurriculumAsync(string studentId) => throw new NotImplementedException();
}