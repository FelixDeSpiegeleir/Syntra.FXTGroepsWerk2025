using Microsoft.EntityFrameworkCore;
using OWN.GroupProject2.DataLayer;
using OWN.GroupProject2.Objects;
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

        public MovieService(MyContext context)
        {
            _context = context;
        }
        //method to add a movie to the database
        public int AddMovie(Movie movie)
        {
            //Check for null
            if (movie == null) throw new ArgumentNullException(nameof(movie));

            try
            {
                //Add the movie and save changes
                _context.Movies.Add(movie);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Exception throw in case of errors
                throw new Exception("Error adding movie", ex);
            }

            //return the id of the movie in case it needs to be used directly
            return movie.Id;
        }

        //method to update an existing movie in the database
        public int UpdateMovie(Movie movie)
        {
            //Check for null
            if (movie == null) throw new ArgumentNullException(nameof(movie));

            try
            {
                //Update the movie and save changes
                _context.Movies.Update(movie);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Exception throw in case of errors
                throw new Exception("Error updating movie", ex);
            }

            //return the id of the movie in case it needs to be used directly
            return movie.Id;
        }

        //method to remove a movie from the database
        public int RemoveMovie(Movie movie)
        {
            //Check for null
            if (movie == null) throw new ArgumentNullException(nameof(movie));

            try
            {
                //Remove the movie and save changes
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Exception throw in case of errors
                throw new Exception("Error removing movie", ex);
            }

            //return the id of the movie in case it needs to be used directly
            return movie.Id;
        }

        //get a list of movies from the datalayer
        public List<Movie> GetMovies()
        {
            var list = _context.Movies.ToList();
            return list;
        }
    }
}
