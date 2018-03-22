using BookstoreApp.Services.ViewModels;
using System.Collections.Generic;

namespace BookstoreApp.Services.Contracts
{
    public interface IBookService
    {
        List<BookViewModel> GetAllBooks();

        List<BookViewModel> GetBookByTitle(string title);

        List<BookViewModel> GetBooksByAuthor(string authorName);

        List<BookViewModel> GetBooksByCategoryId(int id);
    }
}
