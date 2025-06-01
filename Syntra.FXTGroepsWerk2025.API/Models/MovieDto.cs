using System.ComponentModel.DataAnnotations;

namespace Syntra.FXTGroepsWerk2025.API.Models
{
    /// <summary>
    /// Data Transfer Object for Movie.
    /// 
    /// Represents the movie data exchanged between client and server.
    /// Use [FromBody] on controller action parameters to bind JSON request bodies to this DTO.
    /// </summary>
    public class MovieDto
    {
        /// <summary>
        /// The unique identifier of the movie.
        /// Optional in POST requests.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of the movie. This field is required.
        /// </summary>
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        /// <summary>
        /// Release year of the movie. Must be between 1900 and 2100.
        /// </summary>
        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100.")]
        public int ReleaseYear { get; set; }

        /// <summary>
        /// Indicates whether the movie has been watched.
        /// </summary>
        public bool Watched { get; set; }
    }
}
