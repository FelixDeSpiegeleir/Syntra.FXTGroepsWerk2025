using OWN.GroupProject2.DataLayer;
using OWN.GroupProject2.Objects;
using Syntra.FXTGroepsWerk2025.Logic.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Syntra.FXTGroepsWerk2025.Logic.Books
{
    /// <summary>
    /// Provides methods for managing and analyzing books.
    /// </summary>
    public class BookService : IBookService
    {
        private readonly MyContext _context;
        private readonly BookCalculations _calculations;

        public BookService(MyContext context, BookCalculations calculations)
        {
            _context = context;
            _calculations = calculations;
        }

        /// <summary>
        /// Adds a book to the database.
        /// </summary>
        /// <param name="book">The book to add.</param>
        /// <returns>The ID of the added book.</returns>
        public int AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding book", ex);
            }

            return book.Id;
        }

        /// <summary>
        /// Updates an existing book in the database.
        /// </summary>
        /// <param name="book">The book to update.</param>
        /// <returns>The ID of the updated book.</returns>
        public int UpdateBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            try
            {
                _context.Books.Update(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating book", ex);
            }

            return book.Id;
        }

        /// <summary>
        /// Removes a book from the database.
        /// </summary>
        /// <param name="book">The book to remove.</param>
        /// <returns>The ID of the removed book.</returns>
        public int RemoveBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            try
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting book", ex);
            }

            return book.Id;
        }

        /// <summary>
        /// Retrieves a list of all books from the database.
        /// </summary>
        /// <returns>A list of books.</returns>
        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        /// <summary>
        /// Calculates the total number of pages read from the given list of books.
        /// </summary>
        /// <param name="books">A list of books.</param>
        /// <returns>Total pages read.</returns>
        public long TotalPagesReadBooks(List<Book> books)
        {
            return _calculations.TotalPagesRead(books);
        }

        /// <summary>
        /// Calculates the average number of pages read per completed book.
        /// </summary>
        /// <param name="books">A list of books.</param>
        /// <returns>Average pages read per book.</returns>
        public double AveragePagesReadBooks(List<Book> books)
        {
            return _calculations.AveragePages(books);
        }

        /// <summary>
        /// Calculates the total number of completed books.
        /// </summary>
        /// <param name="books">A list of books.</param>
        /// <returns>Total completed books.</returns>
        public long TotalReadBooks(List<Book> books)
        {
            return _calculations.TotalBooksRead(books);
        }
    }
}
