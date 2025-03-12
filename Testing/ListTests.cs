using Microsoft.IdentityModel.Tokens;
using OWN.GroupProject2.DataLayer;
using OWN.GroupProject2.Objects;
using Syntra.FXTGroepsWerk2025.Logic.Books;
using Syntra.FXTGroepsWerk2025.Logic.Movies;

namespace Testing
{
    public class ListTests
    {
        //Strange issue in testing with DI context, need to check later

        //private readonly MyContext _context;
        //public UnitTest1(MyContext context)
        //{
        //        _context = context;
        //}
        [Fact]
        public void GetMovieListTest()
        {
            // Arrange
            var context = new MyContext(); //temporary new context without DI, check for fix later
            var movieService = new MovieService(context); // Assuming MovieService is the service to be tested

            // Act
            List<Movie> result = movieService.GetMovies();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetBookListTest()
        {
            // Arrange
            var context = new MyContext(); //temporary new context without DI, check for fix later
            var bookService = new BookService(context); // Assuming BookService is the service to be tested

            // Act
            List<Book> result = bookService.GetBooks();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

    }
}