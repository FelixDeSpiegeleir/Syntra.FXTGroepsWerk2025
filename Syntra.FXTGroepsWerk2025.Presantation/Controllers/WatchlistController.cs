using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Syntra.FXTGroepsWerk2025.Presantation.Controllers
{
    public class WatchlistController : Controller
    {
        // GET: WatchlistController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WatchlistController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WatchlistController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WatchlistController/Create
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

        // GET: WatchlistController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WatchlistController/Edit/5
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

        // GET: WatchlistController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WatchlistController/Delete/5
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
