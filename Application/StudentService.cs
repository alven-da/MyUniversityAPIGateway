using MyUniversityAPIGateway.Domain;
using MyUniversityAPIGateway.Domain.Repository;

namespace MyUniversityAPIGateway.Application
{
    public class StudentService(IStudentRepository studentRepository) {
        private readonly IStudentRepository _studentRepository = studentRepository;

        public virtual async Task<Student> GetStudentByID(string id) {
            return await _studentRepository.GetProfileAsync(id);
        }
    }
}