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

        private readonly IRepository<User> userRepository;

        private readonly IRepository<UserAddress> userAddressRepository;
        private readonly IRepository<City> cityRepository;
        private readonly IRepository<Country> countryRepository;

        private readonly IRepository<Book> bookRepository;
        private readonly IRepository<Author> authorRepository;
        private readonly IRepository<Category> categoryRepository;

        private readonly IRepository<Order> orderRepository;
        private readonly IReadOnlyRepository<OrderStatus> orderStatusRepository;

        private readonly IRepository<Wishlist> wishlistRepository;

        private readonly IRepository<ShoppingCart> shoppingCartRepository;
        private readonly IReadOnlyRepository<ShoppingCartStatus> shoppingCartStatusRepository;

        private bool disposed = false;


        public UnitOfWork(IBookstoreContext bookstoreContext)
        {
            this.bookstoreContext = bookstoreContext;
        }

        public IRepository<User> UserRepository
        {
            get
            {
                return this.userRepository ?? new GenericRepository<User>(bookstoreContext);
            }
        }

        public IRepository<UserAddress> UserAddressRepository
        {
            get
            {
                return this.userAddressRepository ?? new GenericRepository<UserAddress>(bookstoreContext);
            }
        }

        public IRepository<City> CityRepository
        {
            get
            {
                return this.cityRepository ?? new GenericRepository<City>(bookstoreContext);
            }
        }

        public IRepository<Country> CountryRepository
        {
            get
            {
                return this.countryRepository ?? new GenericRepository<Country>(bookstoreContext);
            }
        }

        public IRepository<Book> BookRepository
        {
            get
            {
                return this.bookRepository ?? new GenericRepository<Book>(bookstoreContext);
            }
        }

        public IRepository<Category> CategoryRepository
        {
            get
            {
                return this.categoryRepository ?? new GenericRepository<Category>(bookstoreContext);
            }
        }

        public IRepository<Author> AuthorRepository
        {
            get
            {
                return this.authorRepository ?? new GenericRepository<Author>(bookstoreContext);
            }
        }

        public IRepository<Order> OrderRepository
        {
            get
            {
                return this.orderRepository ?? new GenericRepository<Order>(bookstoreContext);
            }
        }

        public IReadOnlyRepository<OrderStatus> OrderStatusRepository
        {
            get
            {
                return this.orderStatusRepository ?? new GenericRepository<OrderStatus>(bookstoreContext);
            }
        }

        public IRepository<Wishlist> WishlistRepository
        {
            get
            {
                return this.wishlistRepository ?? new GenericRepository<Wishlist>(bookstoreContext);
            }
        }

        public IRepository<ShoppingCart> ShoppingCartRepository
        {
            get
            {
                return this.shoppingCartRepository ?? new GenericRepository<ShoppingCart>(bookstoreContext);
            }
        }

        public IReadOnlyRepository<ShoppingCartStatus> ShoppingCartStatusRepository
        {
            get
            {
                return this.shoppingCartStatusRepository ?? new GenericRepository<ShoppingCartStatus>(bookstoreContext);
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
