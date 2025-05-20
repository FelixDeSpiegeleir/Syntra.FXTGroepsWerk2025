using Microsoft.EntityFrameworkCore;
using OWN.GroupProject2.DataLayer;
using OWN.GroupProject2.Objects;
using Syntra.FXTGroepsWerk2025.Logic.Books;
using Syntra.FXTGroepsWerk2025.Logic.Calculations;
using Syntra.FXTGroepsWerk2025.Logic.Movies;
using Xunit;

namespace Testing
{
    public class ListTests
    {
        private MyContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<MyContext>()
                .UseInMemoryDatabase(databaseName: "TestDb") // Use unique DB name per test class if needed
                .Options;

            var context = new MyContext(options);

            // Seed sample data if necessary for tests
            if (!context.Movies.Any())
            {
                context.Movies.AddRange(new List<Movie>
                {
                    new Movie { Id = 1, Title = "Inception", Duration = 148 },
                    new Movie { Id = 2, Title = "The Godfather", Duration = 175 }
                });
                context.SaveChanges();
            }

            if (!context.Books.Any())
            {
                context.Books.AddRange(new List<Book>
                {
                    new Book { Id = 1, Title = "To Kill a Mockingbird", Pages = 280 },
                    new Book { Id = 2, Title = "1984", Pages = 328 }
                });
                context.SaveChanges();
            }

            return context;
        }

        [Fact]
        public void GetMovieListTest()
        {
            using var context = CreateInMemoryContext();
            var calculations = new MovieCalculations();
            var movieService = new MovieService(context, calculations);

            var result = movieService.GetMovies();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetBookListTest()
        {
            using var context = CreateInMemoryContext();
            var calculations = new BookCalculations();
            var bookService = new BookService(context, calculations);

            var result = bookService.GetBooks();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
