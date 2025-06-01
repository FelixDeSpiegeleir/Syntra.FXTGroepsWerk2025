namespace Syntra.FXTGroepsWerk2025.API.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

/// <summary>
/// Service responsible for generating JWT (JSON Web Token) tokens for authenticated users.
/// Uses configuration from appsettings.json to build the token.
/// </summary>
public class JwtTokenService
{
    private readonly IConfiguration _config;

    /// <summary>
    /// Initializes a new instance of the JwtTokenService class with injected configuration.
    /// </summary>
    /// <param name="config">Application configuration used to retrieve JWT settings.</param>
    public JwtTokenService(IConfiguration config)
    {
        _config = config;
    }

    /// <summary>
    /// Generates a signed JWT token for the specified username.
    /// </summary>
    /// <param name="username">The username for whom the token is issued.</param>
    /// <returns>A JWT token as a string.</returns>
    public string GenerateToken(string username)
    {
        // Retrieve JWT-related configuration values
        var jwtSettings = _config.GetSection("JwtSettings");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));

        // Define the claims to include in the token (subject and unique ID)
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // Create signing credentials using the secret key and HMAC SHA-256 algorithm
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Build the JWT token
        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["ExpiryMinutes"])),
            signingCredentials: creds
        );

        // Serialize and return the token
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
