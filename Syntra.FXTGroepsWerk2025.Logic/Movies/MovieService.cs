using Microsoft.EntityFrameworkCore;
using OWN.GroupProject2.DataLayer;
using OWN.GroupProject2.Objects;
using Syntra.FXTGroepsWerk2025.Logic.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.FXTGroepsWerk2025.Logic.Movies
{
    public class MovieService : IMovieService
    {
        private readonly MyContext _context;
        private readonly MovieCalculations _calculations;

        public MovieService(MyContext context, MovieCalculations calculations)
        {
            _context = context;
            _calculations = calculations;
        }

        /// <summary>
        /// Adds a movie to the database.
        /// </summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The ID of the added movie.</returns>
        public int AddMovie(Movie movie)
        {
            if (movie == null) throw new ArgumentNullException(nameof(movie));

            try
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding movie", ex);
            }

            return movie.Id;
        }

        /// <summary>
        /// Updates an existing movie in the database.
        /// </summary>
        /// <param name="movie">The movie to update.</param>
        /// <returns>The ID of the updated movie.</returns>
        public int UpdateMovie(Movie movie)
        {
            if (movie == null) throw new ArgumentNullException(nameof(movie));

            try
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating movie", ex);
            }

            return movie.Id;
        }

        /// <summary>
        /// Removes a movie from the database.
        /// </summary>
        /// <param name="movie">The movie to remove.</param>
        /// <returns>The ID of the removed movie.</returns>
        public int RemoveMovie(Movie movie)
        {
            if (movie == null) throw new ArgumentNullException(nameof(movie));

            try
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error removing movie", ex);
            }

            return movie.Id;
        }

        /// <summary>
        /// Retrieves a list of all movies from the database.
        /// </summary>
        /// <returns>A list of movies.</returns>
        public List<Movie> GetMovies()
        {
            var list = _context.Movies.ToList();
            return list;
        }

        /// <summary>
        /// Calculates the total number of minutes watched across all provided movies.
        /// </summary>
        /// <param name="movies">A list of movies.</param>
        /// <returns>Total minutes watched.</returns>
        public long TotalMinutesWatchedMovies(List<Movie> movies)
        {
            var total = _calculations.TotalMinutesWatched(movies);
            return total;
        }

        /// <summary>
        /// Calculates the average number of minutes watched per movie.
        /// </summary>
        /// <param name="movies">A list of movies.</param>
        /// <returns>Average minutes watched.</returns>
        public double AverageMinutesWatchedMovies(List<Movie> movies)
        {
            var average = _calculations.AverageMinutesWatched(movies);
            return average;
        }

        /// <summary>
        /// Calculates the total number of watched movies.
        /// </summary>
        /// <param name="movies">A list of movies.</param>
        /// <returns>Total watched movies.</returns>
        public long TotalWatchedMovies(List<Movie> movies)
        {
            var total = _calculations.TotalMoviesWatched(movies);
            return total;
        }
    }
}
