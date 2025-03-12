using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OWN.GroupProject2.Objects;
using Syntra.FXTGroepsWerk2025.Logic.Movies;

namespace Syntra.FXTGroepsWerk2025.Presantation.Controllers
{
    public class MovieController : Controller
    {
        //// tempt movie list for testing
        //static List<MovieModel> TempMovies = MovieModel.GetTempMovies();
        static IMovieService MovieService { get; set; }
        static List<Movie> MovieList { get; set; }
        static List<MovieModel> ModelList { get; set; }

        // GET: MovieController
        public IActionResult Index([FromServices] IMovieService serv)
        {
            // for actual data
            MovieService = serv;

            MovieList = serv.GetMovies();

            ModelList = MovieList.Select(movie => new MovieModel
            {
                Id = movie.Id,
                Title = movie.Title,
                IsCompleted = movie.IsCompleted,
                Genre = movie.Genre,
                CustomGenre = movie.CustomGenre,
                Duration = movie.Duration,
                Year = movie.Year,
                Director = movie.Director,
                DirectorId = movie.Director.Id,
                IMDBId = movie.IMDBId
            }).ToList();

            return View(ModelList);

            //// for testing
            //return View(TempMovies);
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
