using BookstoreApp.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BookstoreApp.Data
{
    public interface IBookstoreContext : IDisposable
    {
        IDbSet<Wishlist> Wishlists { get; set; }

        IDbSet<Book> Books { get; set; }
        IDbSet<BookImage> BookImages { get; set; }
        IDbSet<Category> Categories { get; set; }
        IDbSet<Author> Authors { get; set; }

        IDbSet<Order> Orders { get; set; }
        IDbSet<OrderStatus> OrderStatuses { get; set; }
        
        IDbSet<ShoppingCart> ShoppingCarts { get; set; }
        IDbSet<ShoppingCartStatus> ShoppingCartStatuses { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
