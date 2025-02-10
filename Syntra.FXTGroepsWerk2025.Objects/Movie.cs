using System.ComponentModel.DataAnnotations;

namespace OWN.GroupProject2.Objects
{
    public class Movie : WatchListItem
    {
        public int Duration { get; set; } // Duration in minutes
        public virtual Director Director { get; set; }
    }
}
