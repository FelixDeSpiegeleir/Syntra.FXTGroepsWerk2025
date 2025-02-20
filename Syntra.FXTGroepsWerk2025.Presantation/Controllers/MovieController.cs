using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OWN.GroupProject2.Objects;
using Syntra.FXTGroepsWerk2025.Logic.Movies;

namespace Syntra.FXTGroepsWerk2025.Presantation.Controllers
{
    public class MovieController : Controller
    {
        // tempt movie list for testing
        // static List<MovieModel> Movies = MovieModel.GetTempMovies();
        static IMovieService MovieService { get; set; }
        static List<Movie> MovieList { get; set; }

        // GET: MovieController
        public IActionResult Index([FromServices]IMovieService serv)
        {
            MovieService = serv;
            MovieList = serv.GetMovies();
            return View(MovieList);
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
