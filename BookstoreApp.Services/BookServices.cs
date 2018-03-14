using BookstoreApp.Data;
using BookstoreApp.Models;

namespace BookstoreApp.Services
{
    public class BookServices
    {
        private readonly IBookstoreContext context;

        public BookServices(IBookstoreContext context)
        {
            this.context = context;
        }

        public void AddBook(Book book)
        {
            this.context.Books.Add(book);
        }
    }
}
