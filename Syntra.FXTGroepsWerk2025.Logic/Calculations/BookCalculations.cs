using OWN.GroupProject2.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.FXTGroepsWerk2025.Logic.Calculations
{
    /// <summary>
    /// Provides calculation methods related to books.
    /// </summary>
    public class BookCalculations
    {
        /// <summary>
        /// Calculates the total number of pages of all completed books.
        /// </summary>
        /// <param name="booksList">A list of books.</param>
        /// <returns>The total number of pages read.</returns>
        public long TotalPagesRead(List<Book> booksList)
        {
            if (booksList == null) throw new ArgumentNullException(nameof(booksList));

            long totalPages = booksList
                .Where(p => p.IsCompleted == true)
                .Sum(p => p.Pages);

            return totalPages;
        }

        /// <summary>
        /// Calculates the average number of pages per completed book.
        /// </summary>
        /// <param name="booksList">A list of books.</param>
        /// <returns>The average number of pages per completed book.</returns>
        public double AveragePages(List<Book> booksList)
        {
            if (booksList == null) throw new ArgumentNullException(nameof(booksList));

            double averagePages = booksList
                .Where(p => p.IsCompleted == true)
                .Average(p => p.Pages);

            return averagePages;
        }

        /// <summary>
        /// Calculates the total number of completed books.
        /// </summary>
        /// <param name="booksList">A list of books.</param>
        /// <returns>The total number of books read.</returns>
        public long TotalBooksRead(List<Book> booksList)
        {
            if (booksList == null) throw new ArgumentNullException(nameof(booksList));

            long totalBooks = booksList
                .Where(p => p.IsCompleted == true)
                .Count();

            return totalBooks;
        }
    }
}
