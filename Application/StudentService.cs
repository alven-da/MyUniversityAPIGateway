using MyUniversityAPIGateway.Application.Dto;
using MyUniversityAPIGateway.Domain;
using MyUniversityAPIGateway.Domain.Repository;

namespace MyUniversityAPIGateway.Application
{
    public class StudentService(IStudentRepository studentRepository) {
        private readonly IStudentRepository _studentRepository = studentRepository;

        private StudentDto ToDto(Student student) {
            return new StudentDto {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            };
        }

        public virtual async Task<StudentDto> GetStudentByID(string id) {
            var student = await _studentRepository.GetProfileAsync(id);
            return ToDto(student);
        }
    }
}