using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BookstoreApp.Data;
using BookstoreApp.Models;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.ViewModels;

namespace BookstoreApp.API.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
        }

        public BookController()
        {

        }
        public List<BookViewModel> GetAllBooks()
        {
            var books = new List<BookViewModel>();
            books = this.bookService.GetAllBooks();

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
        private BookstoreContext db = new BookstoreContext();

        //// GET: Book
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.BookImage).Include(b => b.Category);

            return View(books.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
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
