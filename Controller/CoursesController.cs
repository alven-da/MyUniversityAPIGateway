using Microsoft.AspNetCore.Mvc;

namespace MyUniversityAPIGateway.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase {

        [HttpGet]
        public IActionResult Get() {
            var courses = new List<string> { "Course 1", "Course 2", "Course 3" };
            return Ok(courses);
        }
    }
}