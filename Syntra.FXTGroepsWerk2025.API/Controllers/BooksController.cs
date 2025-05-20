using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OWN.GroupProject2.Objects;
using Syntra.FXTGroepsWerk2025.Logic.Books;

namespace YourApiProject.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            return _bookService.GetBooks();
        }

        [HttpGet("read")]
        public ActionResult<long> GetTotalRead()
        {
            var books = _bookService.GetBooks();
            return _bookService.TotalReadBooks(books);
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            _bookService.AddBook(book);
            return CreatedAtAction(nameof(GetAll), new { id = book.Id }, book);
        }
    }
}
