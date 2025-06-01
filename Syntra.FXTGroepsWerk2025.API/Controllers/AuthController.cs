using Microsoft.AspNetCore.Mvc;
using Syntra.FXTGroepsWerk2025.API.Services;
using System.ComponentModel.DataAnnotations;

namespace Syntra.FXTGroepsWerk2025.API.Controllers
{
    // Marks this as an API controller, enabling automatic binding, model validation, etc.
    [ApiController]

    // Sets the base route to /api/auth for all actions in this controller.
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // Service responsible for generating JWT tokens.
        private readonly JwtTokenService _tokenService;

        // Constructor that injects the JwtTokenService.
        public AuthController(JwtTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        /// POST: /api/auth/login
        /// Authenticates a user using hardcoded credentials and returns a JWT token if successful.
        /// In a real application, replace the hardcoded check with proper database/user-store validation.
        /// </summary>
        /// <param name="login">The login credentials (username and password).</param>
        /// <returns>A JWT token if the credentials are valid; otherwise, 401 Unauthorized.</returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto login)
        {
            // NOTE: This is a placeholder for demonstration or testing purposes.
            // In production, validate against a secure user store or identity provider.
            if (login.Username == "test" && login.Password == "password")
            {
                var token = _tokenService.GenerateToken(login.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }

    /// <summary>
    /// Data Transfer Object representing user login credentials.
    /// </summary>
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
