using BookstoreApp.Models;
using System.Data.Entity;

namespace BookstoreApp.Data
{
    public interface IBookstoreContext
    {
        IDbSet<User> Users { get; set; }
        IDbSet<UserAddress> UserAddresses { get; set; }
        IDbSet<Country> Countries { get; set; }
        IDbSet<City> Cities { get; set; }

        IDbSet<Wishlist> Wishlists { get; set; }
        IDbSet<WishlistItem> WishlistItems { get; set; }

        IDbSet<Book> Books { get; set; }
        IDbSet<Category> Categories { get; set; }
        IDbSet<Author> Authors { get; set; }

        IDbSet<Order> Orders { get; set; }
        IDbSet<OrderStatus> OrderStatuses { get; set; }
        
        IDbSet<ShoppingCart> ShoppingCarts { get; set; }
        IDbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        IDbSet<ShoppingCartStatus> ShoppingCartStatuses { get; set; }
        

        void SaveChanges();
    }
}
