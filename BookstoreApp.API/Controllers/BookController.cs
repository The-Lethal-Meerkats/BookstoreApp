using System.Linq;
using System.Web.Mvc;
using BookstoreApp.Services.Contracts;

namespace BookstoreApp.API.Controllers
{
    // [Authorize]
    public class BookController : Controller
    {
        private IBookService bookService;

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

        public ActionResult BooksByTitleResult(string title)
        {
            var books = this.bookService.GetBooksByTitle(title);

            if (books == null)
            {
                return HttpNotFound("No such book found in collection.");
            }

            return View(books);
        }

        public ActionResult BooksByAuthorResult(string title)
        {
            var books = this.bookService.GetBooksByAuthor(title);

            if (books == null)
            {
                return HttpNotFound("No such auhtor found in collection.");
            }

            return View(books);
        }
    }
}
