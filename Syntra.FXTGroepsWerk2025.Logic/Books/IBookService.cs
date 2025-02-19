using OWN.GroupProject2.Objects;

namespace Syntra.FXTGroepsWerk2025.Logic.Books
{
    public interface IBookService
    {
        int AddBook(Book book);
        List<Book> GetBooks();
        int RemoveBook(Book book);
        int UpdateBook(Book book);
    }
}