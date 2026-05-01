using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyUniversityAPIGateway.Application;
using MyUniversityAPIGateway.Extensions;

namespace MyUniversityAPIGateway.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController(StudentService studentService) : ControllerBase {
        
        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> GetMyProfile() {
            
            var studentId = User?.GetUserId();

            if (string.IsNullOrEmpty(studentId)) {
                return Unauthorized("Token is missing user identification.");
            }

            var student = await studentService.GetStudentByID(studentId);

            if (student == null) {
                return NotFound();
            }

            return Ok(student);
        }
    }
}