using Microsoft.AspNetCore.Mvc;
using Syntra.FXTGroepsWerk2025.API.Services;

namespace Syntra.FXTGroepsWerk2025.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _tokenService;

        public AuthController(JwtTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto login)
        {
            // In a real environment, validate username/password from database
            if (login.Username == "test" && login.Password == "password")
            {
                var token = _tokenService.GenerateToken(login.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
