using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Services;

namespace SchoolManagementSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _studentService.GetAll();
            return Ok(response);
        }
    }
}
