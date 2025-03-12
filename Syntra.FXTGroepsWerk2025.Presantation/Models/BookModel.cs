using OWN.GroupProject2.Objects;

namespace Syntra.FXTGroepsWerk2025.Presantation.Models
{
    public class BookModel : WatchListItem
    {
        /// <summary>
        /// Gets or sets the author of the book.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the publication year of the book.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// gets the pagecount of the book
        /// </summary>  
        public int Pages { get; set; }

    }
}
