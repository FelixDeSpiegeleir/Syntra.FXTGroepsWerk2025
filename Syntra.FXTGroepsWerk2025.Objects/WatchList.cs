﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OWN.GroupProject2.Objects
{
    /// <summary>
    /// Enumeration representing different genres for watch list items.
    /// </summary>
    public enum GenreType
    {
        Action,         // 0
        Comedy,         // 1
        Drama,          // 2
        Fantasy,        // 3
        Horror,         // 4
        Mystery,        // 5
        Romance,        // 6
        SciFi,          // 7
        Thriller,       // 8
        Documentary,    // 9
        Historical,     // 10
        Philosophical,  // 11
        Epic,           // 12
        Crime,          // 13
        Other           // 14
    }

    /// <summary>
    /// Represents a watch list containing multiple watch list items.
    /// </summary>
    public class WatchList
    {
        /// <summary>
        /// Gets or sets the unique identifier for the watch list.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the watch list.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date when the watch list was created.
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the list of items in the watch list.
        /// </summary>
        public virtual List<WatchListItem> Items { get; set; } = new List<WatchListItem>();

        /// <summary>
        /// Gets the total number of completed items in the watch list.
        /// </summary>
        public int TotalCompleted => Items.Count(item => item.IsCompleted);

        /// <summary>
        /// Gets the total number of pending items in the watch list.
        /// </summary>
        public int TotalPending => Items.Count(item => !item.IsCompleted);

        /// <summary>
        /// Gets a value indicating whether all items in the watch list are completed.
        /// </summary>
        public bool IsComplete => Items.All(item => item.IsCompleted);
    }

    /// <summary>
    /// Represents an abstract base class for a watch list item.
    /// </summary>
    public abstract class WatchListItem
    {
        /// <summary>
        /// Gets or sets the unique identifier for the watch list item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the watch list item.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the watch list item is completed.
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Gets or sets the genre of the watch list item.
        /// </summary>
        public GenreType Genre { get; set; }

        /// <summary>
        /// Gets or sets a custom genre for the watch list item if "Other" is selected.
        /// </summary>
        // Ensure CustomGenre is provided if 'Other' is selected
        public string? CustomGenre { get; set; }

        /// <summary>
        /// Gets or sets the genre that the item belongs to.
        /// </summary>
        
        public bool IsCustomGenreRequired()
        {
            return Genre == GenreType.Other && string.IsNullOrWhiteSpace(CustomGenre);
        }
    }
}
