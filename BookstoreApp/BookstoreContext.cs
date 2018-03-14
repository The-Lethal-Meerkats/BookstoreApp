using BookstoreApp.Models;
using System;
using System.Data.Entity;

namespace BookstoreApp.Data
{
    public class BookstoreContext : DbContext, IBookstoreContext
    {
        public BookstoreContext() : base("name=BookStore")
        {

        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Wishlist> Wishlists { get; set; }
        public IDbSet<Book> Books { get; set; }
        public IDbSet<Author> Authors { get; set; }
        public IDbSet<Category> Categories { get; set; }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
