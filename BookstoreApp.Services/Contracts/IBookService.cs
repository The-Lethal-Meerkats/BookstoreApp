using BookstoreApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreApp.Services.Contracts
{
    public interface IBookService
    {
        IList<Book> GetAllBooks();

        IList<Book> GetBookByTitle(string title);

        IList<Book> GetBooksByAuthor(string authorName);

        IList<Book> GetBooksByCategoryId(int id);
    }
}
