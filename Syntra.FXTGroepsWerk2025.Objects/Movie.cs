using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OWN.GroupProject2.Objects
{
    public class Movie : WatchListItem
    {
        /// <summary>
        /// Gets or sets the duration of the movie in minutes.
        /// </summary>
        [Column("PagesOrDuration")]
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets the year the movie was released.
        /// </summary>
        [Column("Year")]
        public int Year { get; set; } // Year the movie was released

        /// <summary>
        /// Gets or sets the director of the movie.
        /// </summary>
        [JsonIgnore]
        public virtual Director Director { get; set; }

        /// <summary>
        /// Place for the IMDB id of the movie.
        /// </summary>
        [Column("IMDBId")]
        public string IMDBId { get; set; } = string.Empty;
    }
}
