using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.DTOs;
using SchoolManagementSystem.Infrastructure.Authorize;
using SchoolManagementSystem.Interfaces;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomAuthorize]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            this._subjectService = subjectService;
        }
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _subjectService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorDetails = new
                {
                    message = ex.Message,
                    innerException = ex.InnerException?.Message
                };
                return BadRequest(errorDetails);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = await _subjectService.Get(id);
                return response == null ? NotFound(new { message = $"Subject with ID {id} was not found." }) : Ok(response);
            }
            catch (Exception ex)
            {
                var errorDetails = new
                {
                    message = ex.Message,
                    innerException = ex.InnerException?.Message
                };
                return BadRequest(errorDetails);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SubjectDTO subject)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var response = await _subjectService.Add(subject);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorDetails = new
                {
                    message = ex.Message,
                    innerException = ex.InnerException?.Message
                };
                return BadRequest(errorDetails);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SubjectDTO subject)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var subjectById = await _subjectService.Get(subject.SubjectID);
                if (subjectById is null)
                    return NotFound(new { message = $"Subject with ID {subject.SubjectID} was not found." });

                var response = await _subjectService.Edit(subject);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorDetails = new
                {
                    message = ex.Message,
                    innerException = ex.InnerException?.Message
                };
                return BadRequest(errorDetails);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var response = await _subjectService.Delete(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorDetails = new
                {
                    message = ex.Message,
                    innerException = ex.InnerException?.Message
                };
                return BadRequest(errorDetails);
            }
        }
    }
}