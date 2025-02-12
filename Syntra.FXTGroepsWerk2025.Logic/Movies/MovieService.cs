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
        //method to add a movie to the database
        public int AddMovie(Movie movie)
        {
            //Check for null
            if (movie == null) throw new ArgumentNullException(nameof(movie));
            //initiate context
            using (var ctx = new MyContext())
            {
                try
                {
                    //Add the movie and save changes
                    ctx.Movies.Add(movie);
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    //Exception throw in case of errors
                    throw new Exception("Error adding movie", ex);
                }
            }
            //return the id of the movie in case it needs to be used directly
            return movie.Id;
        }

        //method to update an existing movie in the database
        public int UpdateMovie(Movie movie)
        {
            //Check for null
            if (movie == null) throw new ArgumentNullException(nameof(movie));
            //initiate context
            using (var ctx = new MyContext())
            {
                try
                {
                    //Update the movie and save changes
                    ctx.Movies.Update(movie);
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    //Exception throw in case of errors
                    throw new Exception("Error updating movie", ex);
                }
            }
            //return the id of the movie in case it needs to be used directly
            return movie.Id;
        }

        //method to remove a movie from the database
        public int RemoveMovie(Movie movie)
        {
            //Check for null
            if (movie == null) throw new ArgumentNullException(nameof(movie));
            //initiate context
            using (var ctx = new MyContext())
            {
                try
                {
                    //Remove the movie and save changes
                    ctx.Movies.Remove(movie);
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    //Exception throw in case of errors
                    throw new Exception("Error removing movie", ex);
                }
            }
            //return the id of the movie in case it needs to be used directly
            return movie.Id;
        }

        public List<Movie> GetMovies()
        {
            var list = new List<Movie>();

           
            return list;// temp
        }
    }
}
