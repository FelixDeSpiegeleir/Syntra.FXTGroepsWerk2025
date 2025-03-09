using Castle.Core.Resource;
using OWN.GroupProject2.DataLayer;
using OWN.GroupProject2.Objects;

namespace Syntra.FXTGroepsWerk2025.Logic.Books
{
    public class BookService : IBookService
    {
        private readonly MyContext _context;
        public BookService(MyContext context)
        {
            _context = context;
        }
        //method to add a book to the database
        public int AddBook(Book book)
        {
            //Check for null
            if (book == null) throw new ArgumentNullException(nameof(book));

            try
            {
                //Add the book and save changes
                _context.Books.Add(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //exception throw in case of errors
                throw new Exception("Error adding book", ex);
            }

            //return the id of the book in case it needs to be used directly
            return book.Id;
        }

        //method to update an existing book in the database
        public int UpdateBook(Book book)
        {
            //Check for null
            if (book == null) throw new ArgumentNullException(nameof(book));

            try
            {
                //Update the existing book and save changes
                _context.Books.Update(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //exception throw in case of errors
                throw new Exception("Error updating book", ex);
            }

            //return the id of the book in case it needs to be used directly
            return book.Id;
        }

        //method to remove a book from the database
        public int RemoveBook(Book book)
        {
            //Check for null
            if (book == null) throw new ArgumentNullException(nameof(book));
            //initiate the context

            try
            {
                //remove the book from the database and save changes
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //exception throw in case of errors
                throw new Exception("Error deleting book", ex);
            }

            //return the id of the book in case it needs to be used directly
            //book is removed, so id is probably not necessary.
            return book.Id;
        }

        //get a list of books from the datalayer
        public List<Book> GetBooks()
        {
            var list = _context.Books.ToList();
            return list;

        }
    }
}
