using Microsoft.AspNetCore.Mvc;

namespace MyUniversityAPIGateway.Controller {
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() {
            return Ok("I'm OK");
        }
    }
}