using Microsoft.EntityFrameworkCore;
using OWN.GroupProject2.DataLayer;
using OWN.GroupProject2.Objects;
using Syntra.FXTGroepsWerk2025.Logic.Books;
using Syntra.FXTGroepsWerk2025.Logic.Calculations;
using Syntra.FXTGroepsWerk2025.Logic.Movies;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Testing
{
    /// <summary>
    /// Contains unit tests to verify retrieval of movies and books from the database.
    /// Uses an isolated in-memory database seeded with sample data.
    /// </summary>
    public class ListTests
    {
        private readonly MyContext _context;               // EF Core in-memory database context
        private readonly MovieCalculations _movieCalculations; // Movie-related calculation logic
        private readonly BookCalculations _bookCalculations;   // Book-related calculation logic
        private readonly MovieService _movieService;       // Service for movie operations
        private readonly BookService _bookService;         // Service for book operations

        /// <summary>
        /// Constructor initializes in-memory database, seeds test data,
        /// and creates service instances with required dependencies.
        /// </summary>
        public ListTests()
        {
            // Use a unique database name per test instance to isolate tests and avoid conflicts
            var options = new DbContextOptionsBuilder<MyContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_" + System.Guid.NewGuid())
                .Options;

            _context = new MyContext(options);

            // Seed initial sample movies and books if database is empty
            SeedData();

            _movieCalculations = new MovieCalculations();
            _bookCalculations = new BookCalculations();

            // Initialize services with context and calculation logic
            _movieService = new MovieService(_context, _movieCalculations);
            _bookService = new BookService(_context, _bookCalculations);
        }

        /// <summary>
        /// Seeds the in-memory database with sample movies and books if they don't already exist.
        /// Ensures tests have consistent data to work with.
        /// </summary>
        private void SeedData()
        {
            if (!_context.Movies.Any())
            {
                _context.Movies.AddRange(new List<Movie>
                {
                    new Movie { Title = "Inception", Duration = 148 },
                    new Movie { Title = "The Godfather", Duration = 175 }
                });
            }

            if (!_context.Books.Any())
            {
                _context.Books.AddRange(new List<Book>
                {
                    new Book { Title = "To Kill a Mockingbird", Pages = 280 },
                    new Book { Title = "1984", Pages = 328 }
                });
            }

            // Persist changes to the in-memory database
            _context.SaveChanges();
        }

        /// <summary>
        /// Tests that the GetMovies method returns a non-null and non-empty list of movies.
        /// </summary>
        [Fact]
        public void GetMovieListTest()
        {
            var result = _movieService.GetMovies();

            Assert.NotNull(result);   // Verify result is not null
            Assert.NotEmpty(result);  // Verify list contains at least one movie
        }

        /// <summary>
        /// Tests that the GetBooks method returns a non-null and non-empty list of books.
        /// </summary>
        [Fact]
        public void GetBookListTest()
        {
            var result = _bookService.GetBooks();

            Assert.NotNull(result);   // Verify result is not null
            Assert.NotEmpty(result);  // Verify list contains at least one book
        }
    }
}
