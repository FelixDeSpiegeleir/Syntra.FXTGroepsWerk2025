using OWN.GroupProject2.Objects;

namespace Syntra.FXTGroepsWerk2025.Logic.Movies
{
    public interface IMovieService
    {
        int AddMovie(Movie movie);
        int RemoveMovie(Movie movie);
        int UpdateMovie(Movie movie);
    }
}