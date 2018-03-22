using BookstoreApp.Models;
using BookstoreApp.Services.ViewModels;
using System.Collections.Generic;

namespace BookstoreApp.Services.Contracts
{
    public interface IBookService
    {
        List<BookViewModel> GetAllBooks();

        List<BookViewModel> GetBooksByTitle(string title);

        IList<Book> GetBooksByAuthor(string authorName);

        IList<Book> GetBooksByCategoryId(int id);
    }
}
