using MyUniversityAPIGateway.Application.Dto;
using MyUniversityAPIGateway.Domain;
using MyUniversityAPIGateway.Domain.Repository;

namespace MyUniversityAPIGateway.Application {
    public class SubjectService(ISubjectRepository subjectRepository)
    {
        private readonly ISubjectRepository _subjectRepository = subjectRepository;

        private SubjectDto ToDto(Subject subject) {
            return new SubjectDto {
                Name = subject.Name,
                Code = subject.Code,
                Year = subject.Year,
                Course = subject.Course,
                Semester = subject.Semester
            };
        }

        public async Task<List<SubjectDto>> GetCurriculumByStudentID(string studentId) {
            var subjects = await _subjectRepository.GetSubjectsByStudentIDAsync(studentId);

            if (subjects == null || !subjects.Any()) {
                throw new Exception("Subjects not found");
            }

            return [.. subjects.Select(ToDto)];
        }
    }
}