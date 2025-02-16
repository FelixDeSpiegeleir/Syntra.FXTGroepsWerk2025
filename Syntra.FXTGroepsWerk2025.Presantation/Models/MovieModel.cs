namespace Syntra.FXTGroepsWerk2025.Presantation.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }

        public MovieModel() { }

        public MovieModel(int id, string title, string director, DateTime releaseDate, string genre, double rating)
        {
            Id = id;
            Title = title;
            Director = director;
            ReleaseDate = releaseDate;
            Genre = genre;
            Rating = rating;
        }
    }
}
