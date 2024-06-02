using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.DTOs;
using SchoolManagementSystem.Interfaces;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _permissionService.GetAll();
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
                var response = await _permissionService.Get(id);
                return response == null ? NotFound(new { message = $"Permission with ID {id} was not found." }) : Ok(response);
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
        public async Task<IActionResult> Post([FromBody] PermissionDTO role)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var response = await _permissionService.Add(role);
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
        public async Task<IActionResult> Put([FromBody] PermissionDTO role)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var roleById = await _permissionService.Get(role.PermissionID);
                if (roleById is null)
                    return NotFound(new { message = $"Permission with ID {role.PermissionID} was not found." });
                var response = await _permissionService.Edit(role);
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
                var response = await _permissionService.Delete(id);
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
