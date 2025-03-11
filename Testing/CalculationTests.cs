using Microsoft.VisualStudio.TestTools.UnitTesting;
using OWN.GroupProject2.DataLayer;
using OWN.GroupProject2.Objects;
using Syntra.FXTGroepsWerk2025.Logic.Calculations;
using Syntra.FXTGroepsWerk2025.Logic.Movies;
using Assert = Xunit.Assert;

namespace Testing;

[TestClass]
public class CalculationTests
{

    [Fact]
    public void TotalMoviesWatchedTest()
    {
        // Arrange
        var context = new MyContext(); //temporary new context without DI, check for fix later
        var movieService = new MovieService(context);
        var movieCalculation = new MovieCalculations();

        long expected = 0; //no movies watched yet

        // Act
        List<Movie> list = movieService.GetMovies();
        long result = movieCalculation.TotalMoviesWatched(list);

        // Assert
        Assert.True(result == expected);
    }

    [Fact]
    public void TotalMinutesWatchedTest()
    {
        // Arrange
        var context = new MyContext(); //temporary new context without DI, check for fix later
        var movieService = new MovieService(context);
        var movieCalculation = new MovieCalculations();

        long expected = 0; //no movies watched yet

        // Act
        List<Movie> list = movieService.GetMovies();
        long result = movieCalculation.TotalMinutesWatched(list);

        // Assert
        Assert.True(expected == result);
    }

    //[Fact]
    //public void AverageMinutesWatchedTest()
    //{
    //    // Arrange
    //    var context = new MyContext(); //temporary new context without DI, check for fix later
    //    var movieService = new MovieService(context);
    //    var movieCalculation = new MovieCalculations();

    //    double expected = 0; //no movies watched yet

    //    // Act
    //    List<Movie> list = movieService.GetMovies();
    //    if (list.Count() == 0)
    //    {
    //        var result = 0;
    //        Assert.Equal(expected, result);
    //    }
    //    else
    //    {
    //        double result = movieCalculation.AverageMinutesWatched(list);
    //        Assert.True(expected == result);
    //    }

    
}
