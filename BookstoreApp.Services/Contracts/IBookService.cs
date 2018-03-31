using BookstoreApp.Services.ViewModels;
using System.Collections.Generic;

namespace BookstoreApp.Services.Contracts
{
    public interface IBookService
    {
        BookImageViewModel GetBookById(int id);

        List<BookViewModel> GetAllBooks();

        List<BookViewModel> GetBooksByTitle(string title);

        List<BookViewModel> GetBooksByAuthor(string authorName);

        List<BookViewModel> GetBooksByCategoryId(int id);
    }
}
