using Microsoft.AspNetCore.Mvc;
using Syntra.FXTGroepsWerk2025.Logic.Movies;
using Syntra.FXTGroepsWerk2025.Logic.Calculations;
using OWN.GroupProject2.Objects;
using Microsoft.AspNetCore.Authorization;

namespace Syntra.FXTGroepsWerk2025.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public ActionResult<List<Movie>> GetAll()
        {
            return _movieService.GetMovies();
        }

        [HttpGet("watched")]
        public ActionResult<long> GetTotalWatched()
        {
            var movies = _movieService.GetMovies();
            return _movieService.TotalWatchedMovies(movies);
        }

        [HttpPost]
        public IActionResult Add(Movie movie)
        {
            _movieService.AddMovie(movie);
            return CreatedAtAction(nameof(GetAll), new { id = movie.Id }, movie);
        }
    }

}
