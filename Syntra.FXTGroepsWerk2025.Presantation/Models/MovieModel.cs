using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OWN.GroupProject2.Objects
{
    /// <summary>
    /// Represents a Movie entity, inheriting from WatchListItem.
    /// </summary>
    public class Movie : WatchListItem
    {
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
    }
}