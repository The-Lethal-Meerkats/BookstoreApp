using BookstoreApp.Models;
using System.Collections.Generic;

namespace BookstoreApp.Services.Contracts
{
    public interface IBookService
    {
        int GetAllBooks();

        IList<Book> GetBookByTitle(string title);

        IList<Book> GetBooksByAuthor(string authorName);

        IList<Book> GetBooksByCategoryId(int id);

    }
}
