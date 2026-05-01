using Microsoft.AspNetCore.Mvc;
using MyUniversityAPIGateway.Application;
using MyUniversityAPIGateway.Domain;

namespace MyUniversityAPIGateway.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController(CourseService courseService) : ControllerBase
    {
        private readonly CourseService _courseService = courseService;

        [HttpGet]
        public async Task<IActionResult> ListAllCourses()
        {
            var courses = await _courseService.ListAllCourses();
            return Ok(courses);
        }
    }
}