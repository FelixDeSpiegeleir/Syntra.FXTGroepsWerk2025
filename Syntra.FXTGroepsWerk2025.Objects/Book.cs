using System.ComponentModel.DataAnnotations;

namespace OWN.GroupProject2.Objects
{
    public class Book : WatchListItem
    {
        public int Pages { get; set; }
        public virtual Author Author { get; set; }
    }
}
