using OWN.GroupProject2.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.FXTGroepsWerk2025.Logic.Calculations
{
    public class MovieCalculations
    {
        //method to calculate the total amount of minutes of all the movies that have been watched
        public long TotalMinutesWatched(List<Movie> movieList)
        {
            //Check for null
            if (movieList == null) throw new ArgumentNullException(nameof(movieList));

            //check the total amount of minutes of movies that have been watched
            long totalMinutes = movieList
                .Where(m => m.IsWatched == true)
                .Sum(m => m.Duration);

            //return the value
            return totalMinutes;
        }

        //method to calculate the average amount of minutes per movie of all movies that have been watched
        public double AverageMinutesWatched(List<Movie> movieList)
        {
            //Check for null
            if (movieList == null) throw new ArgumentNullException(nameof(movieList));

            //check the average amount of minutes of movies that have been watched
            double totalMinutes = movieList
                .Where(m => m.IsWatched == true)
                .Average(m => m.Duration);

            //return the value
            return totalMinutes;
        }

        //method to calculate the total amount of movies that have been watched
        public long TotalMoviesWatched(List<Movie> movieList)
        {
            //Check for null
            if (movieList == null) throw new ArgumentNullException(nameof(movieList));

            //check the total amount of movies that have been watched
            long totalMovies = movieList
                .Where(m => m.IsWatched == true)
                .Count();

            //return the value
            return totalMovies;
        }
    }
}
