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
        IDbSet<Order> Orders { get; set; }
        IDbSet<OrderStatus> OrderStatuses { get; set; }
        IDbSet<Category> Categories { get; set; }
        IDbSet<ShoppingCart> ShoppingCart { get; set; }
        IDbSet<ShoppingCartStatus> ShoppingCartStatuses { get; set; }
        IDbSet<UserAddress> UserAddresses { get; set; }
        IDbSet<Country> Countries { get; set; }
        IDbSet<City> Cities { get; set; }

        void SaveChanges();
    }
}
