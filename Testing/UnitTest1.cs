using OWN.GroupProject2.Objects;
using Syntra.FXTGroepsWerk2025.Logic.Movies;

namespace Testing
{
    public class UnitTest1
    {
        [Fact]
        public void GetListTest()
        {
            // Arrange
            var movieService = new MovieService(); // Assuming MovieService is the service to be tested

            // Act
            List<Movie> result = movieService.GetMovies();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}