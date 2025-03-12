using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OWN.GroupProject2.Objects;
using Syntra.FXTGroepsWerk2025.Logic.Books;
using Syntra.FXTGroepsWerk2025.Presantation.Models;

namespace Syntra.FXTGroepsWerk2025.Presantation.Controllers
{
    public class BookController : Controller
    {
        static IBookService BookService { get; set; }
        static List<Book> BookList { get; set; }
        static List<BookModel> ModelList { get; set; }

        // GET: BookController
        public IActionResult Index([FromServices] IBookService serv)
        {
            // for actual data
            BookService = serv;

            BookList = serv.GetBooks();

            ModelList = BookList.Select(book => new BookModel
            {
                Author = book.Author.Name,
                Title = book.Title,
                Pages = book.Pages,
                Year = book.Year,
                IsCompleted = book.IsCompleted,
                Id = book.Id
         
            }).ToList();

            return View(ModelList);

        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
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

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookController/Edit/5
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

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
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
