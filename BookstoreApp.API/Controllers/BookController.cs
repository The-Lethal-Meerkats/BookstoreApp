﻿using System.Web.Mvc;
using BookstoreApp.Services.Contracts;

namespace BookstoreApp.API.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        //// GET: Book
        public ActionResult BookCollection()
        {
            var books = this.bookService.GetAllBooks();

            return View(books);
        }

        // GET: Book/Details/
        public ActionResult BookDetails(int id)
        {
            var bookModel = this.bookService.GetBookById(id);

            if (bookModel == null)
            {
                return HttpNotFound("No such book found in collection.");
            }

            return View(bookModel);
        }
    }
}
