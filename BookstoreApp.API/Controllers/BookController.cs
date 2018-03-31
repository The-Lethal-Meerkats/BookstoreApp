using System.Web.Mvc;
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
        public ActionResult Index()
        {
            return View();
        }

        // GET: Book/Details/
        public ActionResult Details(int? id)
        {
            return View();
        }

        //// GET: Book/Create
        //public ActionResult Create()
        //{
        //    ViewBag.AuthorId = new SelectList(db.Authors, "Id", "AuthorName");
        //    ViewBag.BookImageId = new SelectList(db.BookImages, "Id", "Id");
        //    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
        //    return View();
        //}

        //// POST: Book/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Isbn,Title,Price,AuthorId,CategoryId,BookImageId")] Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Books.Add(book);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.AuthorId = new SelectList(db.Authors, "Id", "AuthorName", book.AuthorId);
        //    ViewBag.BookImageId = new SelectList(db.BookImages, "Id", "Id", book.BookImageId);
        //    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", book.CategoryId);
        //    return View(book);
        //}

        //// GET: Book/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Book book = db.Books.Find(id);
        //    if (book == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.AuthorId = new SelectList(db.Authors, "Id", "AuthorName", book.AuthorId);
        //    ViewBag.BookImageId = new SelectList(db.BookImages, "Id", "Id", book.BookImageId);
        //    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", book.CategoryId);
        //    return View(book);
        //}

        //// POST: Book/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Isbn,Title,Price,AuthorId,CategoryId,BookImageId")] Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(book).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.AuthorId = new SelectList(db.Authors, "Id", "AuthorName", book.AuthorId);
        //    ViewBag.BookImageId = new SelectList(db.BookImages, "Id", "Id", book.BookImageId);
        //    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", book.CategoryId);
        //    return View(book);
        //}

        //// GET: Book/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Book book = db.Books.Find(id);
        //    if (book == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(book);
        //}

        //// POST: Book/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Book book = db.Books.Find(id);
        //    db.Books.Remove(book);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
