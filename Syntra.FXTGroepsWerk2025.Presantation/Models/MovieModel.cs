using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OWN.GroupProject2.Objects
{
    /// <summary>
    /// Represents a Movie entity, inheriting from WatchListItem.
    /// </summary>
    public class MovieModel : WatchListItem
    {
        /// <summary>
        /// mehtod that gets a temp list of movies for testing
        /// </summary>
        /// <returns></returns>
        //public static List<MovieModel> GetTempMovies()
        //{
        //    return new List<MovieModel>()
        //    {
        //        new MovieModel() { Duration = 120, Director = new Director() { Name = "Steven Spielberg" }, Year = 1993, Title = "Jurassic Park", IsCompleted = true, Genre = GenreType.Action, IMDBId = "tt0107290" },
        //        new MovieModel() { Duration = 142, Director = new Director() { Name = "James Cameron" }, Year = 1997, Title = "Titanic", IsCompleted = true, Genre = GenreType.Romance, IMDBId = "tt0120338" },
        //        new MovieModel() { Duration = 152, Director = new Director() { Name = "Christopher Nolan" }, Year = 2010, Title = "Inception", IsCompleted = true, Genre = GenreType.SciFi, IMDBId = "tt1375666" },
        //        new MovieModel() { Duration = 121, Director = new Director() { Name = "Quentin Tarantino" }, Year = 1994, Title = "Pulp Fiction", IsCompleted = true, Genre = GenreType.Other, IMDBId = "tt0110912" },
        //        new MovieModel() { Duration = 136, Director = new Director() { Name = "Peter Jackson" }, Year = 2001, Title = "The Lord of the Rings: The Fellowship of the Ring", IsCompleted = true, Genre = GenreType.Fantasy, IMDBId = "tt0120737" },
        //        new MovieModel() { Duration = 130, Director = new Director() { Name = "Ridley Scott" }, Year = 2000, Title = "Gladiator", IsCompleted = true, Genre = GenreType.Action, IMDBId = "tt0172495" },
        //        new MovieModel() { Duration = 116, Director = new Director() { Name = "Robert Zemeckis" }, Year = 1985, Title = "Back to the Future", IsCompleted = true, Genre = GenreType.SciFi, IMDBId = "tt0088763" },
        //        new MovieModel() { Duration = 125, Director = new Director() { Name = "Francis Ford Coppola" }, Year = 1972, Title = "The Godfather", IsCompleted = true, Genre = GenreType.Other}
        //    };
        //}

        /// <summary>
        /// Gets or sets the duration of the movie in minutes.
        /// </summary>
        [Required(ErrorMessage = "Duration is required.")]
        [Range(1, 600, ErrorMessage = "Duration must be between 1 and 600 minutes.")]
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets the year the movie was released.
        /// </summary>
        [Required(ErrorMessage = "Release year is required.")]
        [Range(1888, 2100, ErrorMessage = "Please enter a valid year.")] // 1888: First known movie
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the director of the movie.
        /// </summary>
        [Required(ErrorMessage = "Director is required.")]
        public virtual Director Director { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the director in the database.
        /// </summary>
        [ForeignKey("Director")]
        public int DirectorId { get; set; }

        /// <summary>
        /// Gets or sets the IMDB identifier for the movie.
        /// </summary>
        public string IMDBId { get; set; }

    }
}