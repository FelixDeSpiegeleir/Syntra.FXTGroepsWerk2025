using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
    private readonly List<Movie> _movieList;

    // Arrange: Initialize a predefined list of movies to be used for testing
    public CalculationTests()
    {
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
                IsCompleted = false // Not watched
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
                IsCompleted = true // Watched
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
                IsCompleted = true // Watched
            }
        };
    }

    // Test: Verify that the method correctly counts the number of watched movies
    [Fact]
    public void TotalMoviesWatchedTest()
    {
        var movieCalculation = new MovieCalculations();

        long expected = 2; // Two movies are marked as completed
        long result = movieCalculation.TotalMoviesWatched(_movieList);

        Assert.True(result == expected);
    }

    // Test: Verify that the total minutes watched is calculated correctly
    [Fact]
    public void TotalMinutesWatchedTest()
    {
        var movieCalculation = new MovieCalculations();

        long expected = 328; // The sum of durations of watched movies (175 + 153)
        long result = movieCalculation.TotalMinutesWatched(_movieList);

        Assert.True(expected == result);
    }

    // Test: Verify that the average watch time is correctly calculated
    [Fact]
    public void AverageMinutesWatchedTest()
    {
        var movieCalculation = new MovieCalculations();

        double expected = 164; // 328 minutes watched / 2 movies
        double result = movieCalculation.AverageMinutesWatched(_movieList);

        Assert.True(expected == result);
    }
}
