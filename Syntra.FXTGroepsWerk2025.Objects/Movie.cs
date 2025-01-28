using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWN.GroupProject2.Objects
{
    public class Movie
    {
        [Key]
        public int Id { get; private set; }
        public string Title { get; set; }
        public int Duration { get; set; } // Duration in minutes
        public virtual Director Director { get; set; } // virtual for lazy loading
        public bool IsWatched { get; set; }
    }
}
