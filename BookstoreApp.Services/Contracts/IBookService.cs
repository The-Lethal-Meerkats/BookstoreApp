using BookstoreApp.Models;
using BookstoreApp.Services.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreApp.Services.Contracts
{
    public interface IBookService
    {
        List<BookViewModel> GetAllBooks();

        IList<Book> GetBookByTitle(string title);

        IList<Book> GetBooksByAuthor(string authorName);

        IList<Book> GetBooksByCategoryId(int id);
    }
}
