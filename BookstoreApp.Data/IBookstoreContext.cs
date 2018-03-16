using BookstoreApp.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BookstoreApp.Data
{
    public interface IBookstoreContext
    {
        IDbSet<User> Users { get; set; }
        IDbSet<UserAddress> UserAddresses { get; set; }
        IDbSet<Country> Countries { get; set; }
        IDbSet<City> Cities { get; set; }

        IDbSet<Wishlist> Wishlists { get; set; }

        IDbSet<Book> Books { get; set; }
        IDbSet<BookImage> BookImages { get; set; }
        IDbSet<Category> Categories { get; set; }
        IDbSet<Author> Authors { get; set; }

        IDbSet<Order> Orders { get; set; }
        IDbSet<OrderStatus> OrderStatuses { get; set; }
        
        IDbSet<ShoppingCart> ShoppingCarts { get; set; }
        IDbSet<ShoppingCartStatus> ShoppingCartStatuses { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);

        int SaveChanges();
        void Dispose();
    }
}
