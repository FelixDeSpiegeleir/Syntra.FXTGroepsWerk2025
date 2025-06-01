using Microsoft.AspNetCore.Mvc;
using Syntra.FXTGroepsWerk2025.Logic.Movies;
using Syntra.FXTGroepsWerk2025.Logic.Calculations;
using OWN.GroupProject2.Objects;
using Microsoft.AspNetCore.Authorization;
using Syntra.FXTGroepsWerk2025.API.Models;

namespace Syntra.FXTGroepsWerk2025.API.Controllers
{
    // Marks this controller as an API controller, enabling automatic model binding and validation.
    [ApiController]

    // Requires all endpoints in this controller to be accessed by authenticated users only.
    [Authorize]

    // Sets the route to /api/movies for all actions in this controller.
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        // Service that handles movie-related business logic.
        private readonly IMovieService _movieService;

        // Constructor that injects the movie service.
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// GET: /api/movies
        /// Returns a list of all movies.
        /// This endpoint requires authentication.
        /// </summary>
        [HttpGet]
        public ActionResult<List<Movie>> GetAll()
        {
            return _movieService.GetMovies();
        }

        /// <summary>
        /// GET: /api/movies/watched
        /// Returns the total number of movies marked as watched.
        /// This endpoint requires authentication.
        /// </summary>
        [HttpGet("watched")]
        public ActionResult<long> GetTotalWatched()
        {
            var movies = _movieService.GetMovies();
            return _movieService.TotalWatchedMovies(movies);
        }

        /// <summary>
        /// Adds a new movie to the database.
        /// </summary>
        /// <param name="movieDto">The movie data sent in the request body, bound from JSON using [FromBody].</param>
        /// <returns>
        /// Returns 201 Created with the created movie DTO if successful,
        /// or 400 Bad Request if the model state is invalid.
        /// </returns>
        [HttpPost]
        public IActionResult Add([FromBody] MovieDto movieDto)
        {
            // Validate incoming DTO
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map DTO to domain model
            var movie = new Movie
            {
                Title = movieDto.Title,
                Year = movieDto.ReleaseYear,
                IsCompleted = movieDto.Watched
            };

            // Add the movie using the service
            _movieService.AddMovie(movie);

            // Return Created response with location header
            return CreatedAtAction(nameof(GetAll), new { id = movie.Id }, movieDto);
        }

    }
}
