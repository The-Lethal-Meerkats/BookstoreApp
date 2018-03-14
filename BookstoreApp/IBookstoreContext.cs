using BookstoreApp.Models;
using System.Data.Entity;

namespace BookstoreApp.Data
{
    public interface IBookstoreContext
    {
        IDbSet<User> Users { get; set; }
        IDbSet<Wishlist> Wishlists { get; set; }
        IDbSet<Book> Books { get; set; }
        IDbSet<Author> Authors { get; set; }
        IDbSet<Category> Categories { get; set; }

        void SaveChanges();
    }
}
