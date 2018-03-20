using AutoMapper;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.ViewModels;
using System;
using System.Collections.Generic;

namespace BookstoreApp.Client.Controllers
{
    public class BookController
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }

        public List<BookViewModel> GetAllBooks()
        {
            var storedBooks = this.bookService.GetAllBooks();

            List<BookViewModel> booksModel = new List<BookViewModel>();

            foreach (var book in storedBooks)
            {
                var mappedBook = this.mapper.Map<BookViewModel>(book);

                booksModel.Add(mappedBook);
            }

            return booksModel;
        }
    }
}
