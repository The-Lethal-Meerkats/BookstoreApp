using AutoMapper.QueryableExtensions;
using BookstoreApp.Data;
using BookstoreApp.Services.ViewModels;
using System.Collections.Generic;

namespace BookstoreApp.Services
{
    public class BookService
    {
        private readonly IBookstoreContext context;

        public BookService(IBookstoreContext context)
        {
            this.context = context;
        }

        // For the purpose of testing I'm creating the method GetAll which is supposed to take all the books in our DB.
        // Automapper EF 6 is installed in this project which gives us the following benefit used in the GetAll() method.

        public IEnumerable<BookModel> GetAll()
        {
            // With Automapper EF6 Utility

            var books = this.context.Books.ProjectTo<BookModel>();

            return books;
        }

        //public void AddBook(Book book)
        //{
        //    this.context.Books.Add(book);
        //}
    }
}

