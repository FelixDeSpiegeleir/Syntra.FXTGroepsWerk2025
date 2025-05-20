using OWN.GroupProject2.Objects;
using System.Collections.Generic;

namespace Syntra.FXTGroepsWerk2025.Logic.Books
{
    /// <summary>
    /// Provides methods for managing and analyzing books.
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Adds a book to the database.
        /// </summary>
        /// <param name="book">The book to add.</param>
        /// <returns>The ID of the added book.</returns>
        int AddBook(Book book);

        /// <summary>
        /// Removes a book from the database.
        /// </summary>
        /// <param name="book">The book to remove.</param>
        /// <returns>The ID of the removed book.</returns>
        int RemoveBook(Book book);

        /// <summary>
        /// Updates an existing book in the database.
        /// </summary>
        /// <param name="book">The book to update.</param>
        /// <returns>The ID of the updated book.</returns>
        int UpdateBook(Book book);

        /// <summary>
        /// Retrieves a list of all books from the database.
        /// </summary>
        /// <returns>A list of books.</returns>
        List<Book> GetBooks();

        /// <summary>
        /// Calculates the total number of pages read from the given list of books.
        /// </summary>
        /// <param name="books">A list of books.</param>
        /// <returns>Total pages read.</returns>
        long TotalPagesReadBooks(List<Book> books);

        /// <summary>
        /// Calculates the average number of pages read per completed book.
        /// </summary>
        /// <param name="books">A list of books.</param>
        /// <returns>Average pages read per book.</returns>
        double AveragePagesReadBooks(List<Book> books);

        /// <summary>
        /// Calculates the total number of completed books.
        /// </summary>
        /// <param name="books">A list of books.</param>
        /// <returns>Total completed books.</returns>
        long TotalReadBooks(List<Book> books);
    }
}
