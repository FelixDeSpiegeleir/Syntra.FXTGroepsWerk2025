using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWN.GroupProject2.Objects
{
    /// <summary>
    /// Represents a director who can direct multiple movies.
    /// </summary>
    public class Director
    {
        /// <summary>
        /// Gets the unique identifier for the director.
        /// </summary>
        [Key]
        public int Id { get; private set; }

        /// <summary>
        /// Gets or sets the name of the director.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of movies directed by the director.
        /// </summary>
        public virtual List<Movie> Movies { get; set; }
    }
}
