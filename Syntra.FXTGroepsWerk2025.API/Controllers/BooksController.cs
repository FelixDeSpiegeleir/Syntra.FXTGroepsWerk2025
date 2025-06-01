using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OWN.GroupProject2.Objects;
using Syntra.FXTGroepsWerk2025.API.Models;
using Syntra.FXTGroepsWerk2025.Logic.Books;

namespace Syntra.FXTGroepsWerk2025.API.Controllers
{
    // This attribute marks the controller as an API controller.
    // It enables automatic model binding, validation, and other API-specific behaviors.
    [ApiController]

    // This ensures that all actions in the controller require an authenticated user.
    [Authorize]

    // This sets the base route for all endpoints in this controller to: /api/books
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        // The service that provides business logic for books (e.g., retrieving, adding).
        private readonly IBookService _bookService;

        // Constructor injection for the book service.
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// GET: /api/books
        /// Retrieves a paginated list of books.
        /// Requires the user to be authenticated.
        /// 
        /// Pagination parameters:
        /// - page: The page number to retrieve (default is 1).
        /// - pageSize: The number of entries per page (default is 10).
        /// 
        /// Every page will contain up to pageSize entries.
        /// For example, with the default pageSize of 10, a new page is created every 10 entries.
        /// </summary>
        [HttpGet]
        public ActionResult<List<Book>> GetAll(int page = 1, int pageSize = 10)
        {
            var books = _bookService.GetBooks();
            var paged = books.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(paged);
        }


        /// <summary>
        /// GET: /api/books/read
        /// Calculates the total number of books marked as read.
        /// Requires the user to be authenticated.
        /// </summary>
        [HttpGet("read")]
        public ActionResult<long> GetTotalRead()
        {
            var books = _bookService.GetBooks();
            return _bookService.TotalReadBooks(books);
        }

        /// <summary>
        /// Adds a new book to the database.
        /// </summary>
        /// <param name="bookDto">The book data sent in the request body, bound from JSON using [FromBody].</param>
        /// <returns>
        /// Returns 201 Created with the created book DTO if successful,
        /// or 400 Bad Request if the model state is invalid.
        /// </returns>
        [HttpPost]
        public IActionResult Add([FromBody] BookDto bookDto)
        {
            // Validate the incoming DTO based on data annotations
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map DTO to domain model
            var book = new Book
            {
                Title = bookDto.Title,
                Pages = bookDto.Pages,
                IsCompleted = bookDto.IsRead
            };

            // Add the book using the service
            _bookService.AddBook(book);

            // Return Created response with location header pointing to GetAll (or you can point to a GET by Id)
            return CreatedAtAction(nameof(GetAll), new { id = book.Id }, bookDto);
        }

        /// <summary>
        /// Test call
        /// </summary>
        /// <returns></returns>
        [HttpGet("ping")]
        public IActionResult Ping() => Ok("BooksController is alive");

    }
}
