﻿using BookstoreApp.Data.Repository.Contracts;
using BookstoreApp.Models;

namespace BookstoreApp.Data.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }

        IRepository<UserAddress> UserAddressRepository { get; }
        IRepository<City> CityRepository { get; }
        IRepository<Country> CountryRepository { get; }

        IRepository<Book> BookRepository { get; }
        IRepository<Author> AuthorRepository { get; }
        IRepository<Category> CategoryRepository { get; }

        IRepository<Order> OrderRepository { get; }
        IReadOnlyRepository<OrderStatus> OrderStatusRepository { get; }

        IRepository<Wishlist> WishlistRepository { get; }

        IRepository<ShoppingCart> ShoppingCartRepository { get; }
        IReadOnlyRepository<ShoppingCartStatus> ShoppingCartStatusRepository { get; }

        int SaveChanges();
    }
}