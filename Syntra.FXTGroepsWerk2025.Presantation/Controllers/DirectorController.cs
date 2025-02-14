using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Syntra.FXTGroepsWerk2025.Presantation.Controllers
{
    public class DirectorController : Controller
    {
        // GET: DirectorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DirectorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DirectorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DirectorController/Create
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

        // GET: DirectorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DirectorController/Edit/5
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

        // GET: DirectorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DirectorController/Delete/5
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
