using BookstoreApp.Data.Repository.Contracts;
using BookstoreApp.Models;

namespace BookstoreApp.Data.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }

        IRepository<UserAddress> UserAddresses{ get; }
        IRepository<City> Cities{ get; }
        IRepository<Country> Countries { get; }

        IRepository<Book> Books { get; }
        IRepository<Author> Authors { get; }
        IRepository<Category> Categories { get; }

        IRepository<Order> Orders { get; }
        IReadOnlyRepository<OrderStatus> OrderStatuses { get; }

        IRepository<Wishlist> Wishlists { get; }

        IRepository<ShoppingCart> ShoppingCarts { get; }
        IReadOnlyRepository<ShoppingCartStatus> ShoppingCartStatuses { get; }

        int SaveChanges();
    }
}