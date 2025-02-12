using OWN.GroupProject2.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.FXTGroepsWerk2025.Logic.Calculations
{
    public class BookCalculations
    {
        //method to calculate the total amount of pages of all the books that have been read
        public long TotalPagesRead(List<Book> booksList)
        {
            //Check for null
            if (booksList == null) throw new ArgumentNullException(nameof(booksList));

            //Sum up all the 'Pages' properties of all the books in the list that have been read
            long totalPages = booksList
                .Where(p => p.IsCompleted == true)
                .Sum(p => p.Pages);

            //return the value
            return totalPages;
        }

        //method to calculate the average amount of pages per book of all books that have been read
        public double AveragePages(List<Book> booksList)
        {
            //Check for null
            if (booksList == null) throw new ArgumentNullException(nameof(booksList));

            //Get all the books that have been read and check the average of the pagecount
            double averagePages = booksList
                .Where(p => p.IsCompleted == true)
                .Average(p => p.Pages);

            //return the value
            return averagePages;
        }

        //method to calculate the total amount of books that have been read
        public long TotalBooksRead(List<Book> booksList)
        {
            //Check for null
            if (booksList == null) throw new ArgumentNullException(nameof(booksList));

            //Count all the books in the list that have been read
            long totalBooks = booksList
                .Where(p => p.IsCompleted == true)
                .Count();

            //return the value
            return totalBooks;
        }
    }
}
