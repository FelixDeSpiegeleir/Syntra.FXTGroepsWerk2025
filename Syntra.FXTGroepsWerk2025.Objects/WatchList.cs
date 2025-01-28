using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWN.GroupProject2.Objects
{
    public class WatchList
    {
        public enum WatchListType
        {
            Movie,
            Book
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } // Name of the list

        public WatchListType Type { get; set; } 

        public bool IsComplete { get; set; }

        public int PagesOrDuration { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now; // Default to current time

        public List<Movie> MoviesToWatch { get; set; } = new List<Movie>(); //  ( = new List<Movie>() makes it so its name is unique)

        public List<Book> BooksToRead { get; set; } = new List<Book>();

        public List<Movie> CompletedMovies { get; set; } = new List<Movie>();

        public List<Book> CompletedBooks { get; set; } = new List<Book>();

        public int TotalItems => (CompletedMovies?.Count ?? 0) + (CompletedBooks?.Count ?? 0); // Total items completed
    }
}
