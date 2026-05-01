using Microsoft.AspNetCore.Mvc;
using MyUniversityAPIGateway.Application;
using MyUniversityAPIGateway.Extensions;

namespace MyUniversityAPIGateway.Controller
{
    public class SubjectsController(SubjectService subjectService) : ControllerBase {
        
        [HttpGet("curriculum")]
        public async Task<IActionResult> GetCurriculum() {
            var studentId = User?.GetUserId();

            var subjects = await subjectService.GetCurriculumByStudentID(studentId);
            
            return Ok(subjects);
        }
    }
}