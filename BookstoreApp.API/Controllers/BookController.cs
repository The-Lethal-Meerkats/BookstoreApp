using System.Web.Mvc;
using BookstoreApp.Services.Contracts;
using Microsoft.Owin.Security;

namespace BookstoreApp.API.Controllers
{
    public class BookController : Controller
    {
        private IBookService bookService;
        private IAuthenticationManager authManager;

        public BookController(IBookService bookService, IAuthenticationManager authenticationManager)
        {
            this.bookService = bookService;
            this.authManager = authenticationManager;
        }

        //// GET: Book
        public ActionResult BookCollection()
        {
            var books = this.bookService.GetAllBooks();

            return View(books);
        }

        // GET: Book/Details/1
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
