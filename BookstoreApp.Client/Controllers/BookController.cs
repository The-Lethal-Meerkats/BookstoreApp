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
    }
}
