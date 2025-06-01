using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OWN.GroupProject2.DataLayer;
using Syntra.FXTGroepsWerk2025.API.Services;
using Syntra.FXTGroepsWerk2025.Logic.Books;
using Syntra.FXTGroepsWerk2025.Logic.Calculations;
using Syntra.FXTGroepsWerk2025.Logic.Movies;
using System.Text;

namespace Syntra.FXTGroepsWerk2025.API
{
    /// <summary>
    /// Entry point of the ASP.NET Core Web API application.
    /// Configures services, middleware, and authentication.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a new WebApplicationBuilder instance
            var builder = WebApplication.CreateBuilder(args);

            // -----------------------------
            // JWT Authentication Setup
            // -----------------------------

            // Read JWT settings (secret key, issuer, audience, expiry) from configuration
            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];

            // Add JWT authentication service with configuration
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });

            // Add basic authorization service
            builder.Services.AddAuthorization();

            // -----------------------------
            // Register Application Services
            // -----------------------------

            // JWT Token generator service (singleton: one shared instance)
            builder.Services.AddSingleton<JwtTokenService>();

            // Business logic services (scoped: one per request)
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<BookCalculations>();
            builder.Services.AddScoped<MovieCalculations>();

            // Entity Framework DB context (scoped by default)
            builder.Services.AddDbContext<MyContext>();

            // Add controller for model validation
            builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        return new BadRequestObjectResult(context.ModelState);
                    };
                });


            // -----------------------------
            // Swagger/OpenAPI Configuration
            // -----------------------------

            // Enables OpenAPI (Swagger) for documenting and testing APIs
            builder.Services.AddOpenApi();

            // -----------------------------
            // CORS Policy
            // -----------------------------

            // Allow any origin, header, and method (for development or public APIs)
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            // -----------------------------
            // Build and Configure the App
            // -----------------------------

            var app = builder.Build();

            // Apply CORS policy globally
            app.UseCors("AllowAll");

            // Use Swagger/OpenAPI only in development
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            // Enforce HTTPS redirection
            app.UseHttpsRedirection();

            // Enable authentication and authorization middleware
            app.UseAuthentication();
            app.UseAuthorization();

            // Map controller endpoints (API routes)
            app.MapControllers();

            // Start the web application
            app.Run();
        }
    }
}
