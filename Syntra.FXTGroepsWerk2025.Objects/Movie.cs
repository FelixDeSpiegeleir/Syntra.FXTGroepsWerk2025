using System.ComponentModel.DataAnnotations;

namespace OWN.GroupProject2.Objects
{
    public class Movie : WatchListItem
    {
        /// <summary>
        /// Gets or sets the duration of the movie in minutes.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets the year the movie was released.
        /// </summary>
        public int Year { get; set; } // Year the movie was released

        /// <summary>
        /// Gets or sets the director of the movie.
        /// </summary>
        public virtual Director Director { get; set; }

        /// <summary>
        /// Place for the IMDB id of the movie.
        /// </summary>
        public string IMDBId { get; set; } = string.Empty;
    }
}
