using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OWN.GroupProject2.Objects
{
    public class WatchList
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } // Name of the list

        public DateTime CreatedDate { get; set; } = DateTime.Now; // Default to current time

        public List<WatchListItem> Items { get; set; } = new List<WatchListItem>();

        public int TotalCompleted => Items.Count(item => item.IsCompleted); // Completed items count

        public int TotalPending => Items.Count(item => !item.IsCompleted); // Pending items count

        public bool IsComplete => Items.All(item => item.IsCompleted); // True if all are completed
    }

    public abstract class WatchListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
