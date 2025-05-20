using OWN.GroupProject2.Objects;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Book : WatchListItem
{
    /// <summary>
    /// Gets or sets the number of pages in the book.
    /// </summary>
    [Column("PagesOrDuration")]
    public int Pages { get; set; }

    /// <summary>
    /// Gets or sets the year the book was published.
    /// </summary>
    [Column("Year")]
    public int Year { get; set; } // Year the book was published

    /// <summary>
    /// Gets or sets the author of the book.
    /// </summary>
    [JsonIgnore]
    public virtual Author Author { get; set; }

    [Column("GoodReadsId")]
    public string GoodReadsId { get; set; } = string.Empty;
}
