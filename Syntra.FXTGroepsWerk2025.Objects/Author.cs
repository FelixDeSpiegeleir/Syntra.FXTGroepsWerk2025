using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWN.GroupProject2.Objects
{
    public class Author
    {
        /// <summary>
        /// Gets or sets the unique identifier for the author.
        /// </summary>
        [Key]
        public int Id { get; private set; }

        /// <summary>
        /// Gets or sets the name of the author.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of books written by the author.
        /// </summary>
        public virtual List<Book> Books { get; set; }
    }
}
