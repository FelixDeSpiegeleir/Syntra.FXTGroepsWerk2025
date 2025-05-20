using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OWN.GroupProject2.DataLayer;
using OWN.GroupProject2.Objects;
using Syntra.FXTGroepsWerk2025.Logic.Books;
using Syntra.FXTGroepsWerk2025.Logic.Calculations;
using Syntra.FXTGroepsWerk2025.Logic.Movies;
using Assert = Xunit.Assert;

namespace Testing;

/// <summary>
/// Unit tests for verifying movie and book calculations using predefined sample data.
/// </summary>
[TestClass]
public class CalculationTests
{
    private readonly List<Movie> _movieList;           // Sample movies for testing
    private readonly List<Book> _bookList;             // Sample books for testing
    private readonly MyContext _context;               // EF Core In-Memory database context
    private readonly MovieCalculations _movieCalculations; // Logic for movie-specific calculations
    private readonly BookCalculations _bookCalculations;   // Logic for book-specific calculations
    private readonly MovieService _movieService;       // Service encapsulating movie operations
    private readonly BookService _bookService;         // Service encapsulating book operations

    /// <summary>
    /// Constructor initializes sample data and configures EF Core in-memory context and services.
    /// </summary>
    public CalculationTests()
    {
        // Initialize a list of sample movies with properties including director, genre, and completion status
        _movieList = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Title = "Inception",
                Duration = 148,
                Year = 2010,
                Genre = GenreType.SciFi,
                Director = new Director { Name = "Christopher Nolan" },
                IMDBId = "tt1375666",
                IsCompleted = false // Movie not watched yet
            },
            new Movie
            {
                Id = 2,
                Title = "The Godfather",
                Duration = 175,
                Year = 1972,
                Genre = GenreType.Crime,
                Director = new Director { Name = "Francis Ford Coppola" },
                IMDBId = "tt0068646",
                IsCompleted = true // Movie has been watched
            },
            new Movie
            {
                Id = 3,
                Title = "The Dark Knight",
                Duration = 153,
                Year = 2008,
                Genre = GenreType.Action,
                Director = new Director { Name = "Christopher Nolan" },
                IMDBId = "tt0468569",
                IsCompleted = true // Movie has been watched
            }
        };

        // Initialize a list of sample books with authors, genres, and completion status
        _bookList = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "To Kill a Mockingbird",
                Pages = 280,
                Year = 1960,
                Genre = GenreType.Philosophical,
                Author = new Author { Name = "Harper Lee" },
                IsCompleted = true // Book has been read
            },
            new Book
            {
                Id = 2,
                Title = "1984",
                Pages = 328,
                Year = 1949,
                Genre = GenreType.Thriller,
                Author = new Author { Name = "George Orwell" },
                IsCompleted = false // Book not completed yet
            },
            new Book
            {
                Id = 3,
                Title = "The Hobbit",
                Pages = 310,
                Year = 1937,
                Genre = GenreType.Fantasy,
                Author = new Author { Name = "J.R.R. Tolkien" },
                IsCompleted = true // Book has been read
            }
        };

        // Configure EF Core to use an in-memory database named "TestDb" for isolated testing
        var options = new DbContextOptionsBuilder<MyContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        _context = new MyContext(options);

        // Instantiate calculation logic classes
        _movieCalculations = new MovieCalculations();
        _bookCalculations = new BookCalculations();

        // Create service instances with the context and calculation dependencies injected
        _movieService = new MovieService(_context, _movieCalculations);
        _bookService = new BookService(_context, _bookCalculations);
    }

    /// <summary>
    /// Tests that the TotalWatchedMovies method correctly counts movies marked as completed.
    /// </summary>
    [Fact]
    public void TotalMoviesWatchedTest()
    {
        long expected = 2; // Two movies have IsCompleted = true
        long result = _movieService.TotalWatchedMovies(_movieList);

        Assert.True(result == expected);
    }

    /// <summary>
    /// Tests that TotalMinutesWatchedMovies returns the sum of durations for watched movies.
    /// </summary>
    [Fact]
    public void TotalMinutesWatchedTest()
    {
        long expected = 328; // Sum of durations of watched movies (175 + 153)
        long result = _movieService.TotalMinutesWatchedMovies(_movieList);

        Assert.True(expected == result);
    }

    /// <summary>
    /// Tests that AverageMinutesWatchedMovies correctly computes the average duration of watched movies.
    /// </summary>
    [Fact]
    public void AverageMinutesWatchedTest()
    {
        double expected = 164; // Average = 328 total minutes / 2 movies
        double result = _movieService.AverageMinutesWatchedMovies(_movieList);

        Assert.True(expected == result);
    }

    /// <summary>
    /// Tests that TotalReadBooks returns the count of books marked as completed.
    /// </summary>
    [Fact]
    public void TotalBooksReadTest()
    {
        long expected = 2; // Two books have IsCompleted = true
        long result = _bookService.TotalReadBooks(_bookList);

        Assert.True(expected == result);
    }

    /// <summary>
    /// Tests that TotalPagesReadBooks correctly sums pages of completed books.
    /// </summary>
    [Fact]
    public void TotalPagesRead()
    {
        long expected = 590; // Sum of pages of read books (280 + 310)
        long result = _bookService.TotalPagesReadBooks(_bookList);

        Assert.True(expected == result);
    }

    /// <summary>
    /// Tests that AveragePagesReadBooks calculates the average pages per completed book.
    /// </summary>
    [Fact]
    public void AveragePagesPerBookTest()
    {
        double expected = 295; // Average = 590 pages / 2 books
        double result = _bookService.AveragePagesReadBooks(_bookList);

        Assert.True(expected == result);
    }
}
