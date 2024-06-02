using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Services;
using SchoolManagementSystem.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _roleService.GetAll();
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
                var response = await _roleService.Get(id);
                return response == null ? NotFound(new { message = $"Role with ID {id} was not found." }) : Ok(response);
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
        public async Task<IActionResult> Post([FromBody] RoleDTO role)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var response = await _roleService.Add(role);
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
        public async Task<IActionResult> Put([FromBody] RoleDTO role)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var roleById = await _roleService.Get(role.RoleID);
                if(roleById is null)
                    return NotFound(new { message = $"Role with ID {role.RoleID} was not found." });
                var response = await _roleService.Edit(role);
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
                var response = await _roleService.Delete(id);
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
