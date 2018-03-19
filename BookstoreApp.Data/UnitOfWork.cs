using System;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Data.Repository;
using BookstoreApp.Data.Repository.Contracts;
using BookstoreApp.Models;

namespace BookstoreApp.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IBookstoreContext bookstoreContext;

        private readonly IRepository<User> users;

        private readonly IRepository<UserAddress> userAddresses;
        private readonly IRepository<City> cities;
        private readonly IRepository<Country> countries;

        private readonly IRepository<Book> books;
        private readonly IRepository<Author> authors;
        private readonly IRepository<Category> categories;

        private readonly IRepository<Order> orders;
        private readonly IReadOnlyRepository<OrderStatus> orderStatuses;

        private readonly IRepository<Wishlist> wishlists;

        private readonly IRepository<ShoppingCart> shoppingCarts;
        private readonly IReadOnlyRepository<ShoppingCartStatus> shoppingCartStatuses;

        private bool disposed = false;


        public UnitOfWork(IBookstoreContext bookstoreContext)
        {
            this.bookstoreContext = bookstoreContext;
        }

        public IRepository<User> Users
        {
            get
            {
                return this.users ?? new GenericRepository<User>(bookstoreContext);
            }
        }

        public IRepository<UserAddress> UserAddresses
        {
            get
            {
                return this.userAddresses ?? new GenericRepository<UserAddress>(bookstoreContext);
            }
        }

        public IRepository<City> Cities
        {
            get
            {
                return this.cities ?? new GenericRepository<City>(bookstoreContext);
            }
        }

        public IRepository<Country> Countries
        {
            get
            {
                return this.countries ?? new GenericRepository<Country>(bookstoreContext);
            }
        }

        public IRepository<Book> Books
        {
            get
            {
                return this.books ?? new GenericRepository<Book>(bookstoreContext);
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.categories ?? new GenericRepository<Category>(bookstoreContext);
            }
        }

        public IRepository<Author> Authors
        {
            get
            {
                return this.authors ?? new GenericRepository<Author>(bookstoreContext);
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                return this.orders ?? new GenericRepository<Order>(bookstoreContext);
            }
        }

        public IReadOnlyRepository<OrderStatus> OrderStatuses
        {
            get
            {
                return this.orderStatuses ?? new GenericRepository<OrderStatus>(bookstoreContext);
            }
        }

        public IRepository<Wishlist> Wishlists
        {
            get
            {
                return this.wishlists ?? new GenericRepository<Wishlist>(bookstoreContext);
            }
        }

        public IRepository<ShoppingCart> ShoppingCarts
        {
            get
            {
                return this.shoppingCarts ?? new GenericRepository<ShoppingCart>(bookstoreContext);
            }
        }

        public IReadOnlyRepository<ShoppingCartStatus> ShoppingCartStatuses
        {
            get
            {
                return this.shoppingCartStatuses ?? new GenericRepository<ShoppingCartStatus>(bookstoreContext);
            }
        }

        public int SaveChanges()
        {
            return bookstoreContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    bookstoreContext.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
    }
}
