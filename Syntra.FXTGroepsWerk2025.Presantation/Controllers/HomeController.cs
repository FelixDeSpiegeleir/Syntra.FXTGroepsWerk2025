using Microsoft.AspNetCore.Mvc;
using Syntra.FXTGroepsWerk2025.Presantation.Models;
using System.Diagnostics;

namespace Syntra.FXTGroepsWerk2025.Presantation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Method to view the main index
        /// </summary>
        /// <returns> returns view: "Index"</returns>
        public IActionResult Index()
        
        {
            return View();
        }

        /// <summary>
        /// Method to view privecy page
        /// </summary>
        /// <returns> returns view: "Index"</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Method to view movies wishlist
        /// </summary>
        /// <returns>returns view : "Movie"</returns>
        public IActionResult Movies()
        {
            return View();
        }


        /// <summary>
        /// Method to view books wishlist
        /// </summary>
        /// <returns>returns view: "Books"</returns>
        public IActionResult Books()
        {
            return View();
        }

        //public IActionResult Favorites()
        //{
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
