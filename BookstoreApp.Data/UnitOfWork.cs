﻿using System;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Data.Repository;
using BookstoreApp.Data.Repository.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Models.Accounts;

namespace BookstoreApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IBookstoreContext bookstoreContext;
        private IRepository<BookstoreUser> users;
        private IRepository<Book> books;
        private IRepository<Author> authors;
        private IRepository<Category> categories;
        private IRepository<Order> orders;
        private IReadOnlyRepository<OrderStatus> orderStatuses;
        private IRepository<Wishlist> wishlists;
        private IRepository<ShoppingCart> shoppingCarts;
        private IReadOnlyRepository<ShoppingCartStatus> shoppingCartStatuses;

        public UnitOfWork(IBookstoreContext bookstoreContext)
        {
            if (bookstoreContext == null)
            {
                throw new ArgumentNullException("Context should not be null");
            }
            this.bookstoreContext = bookstoreContext;
        }

        public UnitOfWork(
            IBookstoreContext bookstoreContext, 
            IRepository<BookstoreUser> users, 
            IRepository<Book> books,
            IRepository<Author> authors,
            IRepository<Category> categories,
            IRepository<Order> orders,
            IReadOnlyRepository<OrderStatus> orderStatuses,
            IRepository<Wishlist> wishlists,
            IRepository<ShoppingCart> shoppingCarts,
            IReadOnlyRepository<ShoppingCartStatus> shoppingCartStatuses)
        {
            this.bookstoreContext = bookstoreContext;
            this.users = users;
            this.books = books;
            this.authors = authors;
            this.categories = categories;
            this.orders = orders;
            this.orderStatuses = orderStatuses;
            this.wishlists = wishlists;
            this.shoppingCarts = shoppingCarts;
            this.shoppingCartStatuses = shoppingCartStatuses;
        }

        public IRepository<BookstoreUser> Users
        {
            get
            {
                if (this.users == null)
                {
                    this.users = new GenericRepository<BookstoreUser>(bookstoreContext);
                }

                return this.users;
            }
        }

        public IRepository<Book> Books
        {
            get
            {
                if (this.books == null)
                {
                    this.books = new GenericRepository<Book>(bookstoreContext);
                }

                return this.books;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (this.categories == null)
                {
                    this.categories = new GenericRepository<Category>(bookstoreContext);
                }

                return this.categories;
            }
        }

        public IRepository<Author> Authors
        {
            get
            {
                if (this.authors == null)
                {
                    this.authors = new GenericRepository<Author>(bookstoreContext);
                }

                return this.authors;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (this.orders == null)
                {
                    this.orders = new GenericRepository<Order>(bookstoreContext);
                }

                return this.orders;
            }
        }

        public IReadOnlyRepository<OrderStatus> OrderStatuses
        {
            get
            {
                if (this.orderStatuses == null)
                {
                    this.orderStatuses = new GenericRepository<OrderStatus>(bookstoreContext);
                }

                return this.orderStatuses;
            }
        }

        public IRepository<Wishlist> Wishlists
        {
            get
            {
                if (this.wishlists == null)
                {
                    this.wishlists = new GenericRepository<Wishlist>(bookstoreContext);
                }

                return this.wishlists;
            }
        }

        public IRepository<ShoppingCart> ShoppingCarts
        {
            get
            {
                if (this.shoppingCarts == null)
                {
                    this.shoppingCarts = new GenericRepository<ShoppingCart>(bookstoreContext);
                }

                return this.shoppingCarts;
            }
        }

        public IReadOnlyRepository<ShoppingCartStatus> ShoppingCartStatuses
        {
            get
            {
                if (this.shoppingCartStatuses == null)
                {
                    this.shoppingCartStatuses = new GenericRepository<ShoppingCartStatus>(bookstoreContext);
                }

                return this.shoppingCartStatuses;
            }
        }

        public int SaveChanges()
        {
            return bookstoreContext.SaveChanges();
        }
    }
}
