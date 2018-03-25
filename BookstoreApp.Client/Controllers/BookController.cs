using AutoMapper;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.ViewModels;
using System.Collections.Generic;

namespace BookstoreApp.Client.Controllers
{
    public class BookController
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
        }

        public List<BookViewModel> GetAllBooks()
        {
            var books = this.bookService.GetAllBooks();

            return books;
        }

        public List<BookViewModel> GetBookByTitle(string title)
        {
            var books = this.bookService.GetBooksByTitle(title);

            return books;
        }

        public List<BookViewModel> GetBooksByAuthor(string authorName)
        {
            var books = this.bookService.GetBooksByAuthor(authorName);

            return books;
        }

        public List<BookViewModel> GetBooksByCategoryId(int id)
        {
            var books = this.bookService.GetBooksByCategoryId(id);

            return books;
        }
    }
}
