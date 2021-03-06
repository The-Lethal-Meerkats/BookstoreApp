﻿using BookstoreApp.Data.Repository.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Models.Accounts;
using System;

namespace BookstoreApp.Data.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<BookstoreUser> Users { get; }
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