using OWN.GroupProject2.Objects;
using System.Collections.Generic;

namespace Syntra.FXTGroepsWerk2025.Logic.Movies
{
    /// <summary>
    /// Provides methods for managing and analyzing movies.
    /// </summary>
    public interface IMovieService
    {
        /// <summary>
        /// Adds a movie to the database.
        /// </summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The ID of the added movie.</returns>
        int AddMovie(Movie movie);

        /// <summary>
        /// Removes a movie from the database.
        /// </summary>
        /// <param name="movie">The movie to remove.</param>
        /// <returns>The ID of the removed movie.</returns>
        int RemoveMovie(Movie movie);

        /// <summary>
        /// Updates an existing movie in the database.
        /// </summary>
        /// <param name="movie">The movie to update.</param>
        /// <returns>The ID of the updated movie.</returns>
        int UpdateMovie(Movie movie);

        /// <summary>
        /// Retrieves a list of all movies from the database.
        /// </summary>
        /// <returns>A list of movies.</returns>
        List<Movie> GetMovies();

        /// <summary>
        /// Calculates the total number of minutes watched across all provided movies.
        /// </summary>
        /// <param name="movies">A list of movies.</param>
        /// <returns>Total minutes watched.</returns>
        long TotalMinutesWatchedMovies(List<Movie> movies);

        /// <summary>
        /// Calculates the average number of minutes watched per movie.
        /// </summary>
        /// <param name="movies">A list of movies.</param>
        /// <returns>Average minutes watched.</returns>
        double AverageMinutesWatchedMovies(List<Movie> movies);

        /// <summary>
        /// Calculates the total number of watched movies.
        /// </summary>
        /// <param name="movies">A list of movies.</param>
        /// <returns>Total watched movies.</returns>
        long TotalWatchedMovies(List<Movie> movies);
    }
}
