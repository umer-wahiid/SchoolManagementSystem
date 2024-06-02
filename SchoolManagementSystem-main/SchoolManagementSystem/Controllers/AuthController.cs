using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.DTOs;
using SchoolManagementSystem.Interfaces;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }
        [HttpPost]
        public IActionResult Authenticate([FromBody] OAuth oAuth)
        {
            try
            {
                var token = _authService.Authenticate(oAuth);
                if (token == null)
                    return Unauthorized(new { message = "Invalid Credentials" });

                return Ok(new
                {
                    AccessToken = token,
                    AccessType = "Bearer",
                });

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