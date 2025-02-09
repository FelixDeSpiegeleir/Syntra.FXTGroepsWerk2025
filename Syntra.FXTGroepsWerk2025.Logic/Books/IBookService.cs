using OWN.GroupProject2.Objects;

namespace Syntra.FXTGroepsWerk2025.Logic.Books
{
    public interface IBookService
    {
        int AddBook(Book book);
        int RemoveBook(Book book);
        int UpdateBook(Book book);
    }
}