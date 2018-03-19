using System;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Data.Repository;
using BookstoreApp.Data.Repository.Contracts;
using BookstoreApp.Models;

namespace BookstoreApp.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IBookstoreContext context = new BookstoreContext();

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

        public IRepository<User> UserRepository
        {
            get
            {
                return this.userRepository ?? new GenericRepository<User>(context);
            }
        }

        public IRepository<UserAddress> UserAddressRepository
        {
            get
            {
                return this.userAddressRepository ?? new GenericRepository<UserAddress>(context);
            }
        }

        public IRepository<City> CityRepository
        {
            get
            {
                return this.cityRepository ?? new GenericRepository<City>(context);
            }
        }

        public IRepository<Country> CountryRepository
        {
            get
            {
                return this.countryRepository ?? new GenericRepository<Country>(context);
            }
        }

        public IRepository<Book> BookRepository
        {
            get
            {
                return this.bookRepository ?? new GenericRepository<Book>(context);
            }
        }

        public IRepository<Category> CategoryRepository
        {
            get
            {
                return this.categoryRepository ?? new GenericRepository<Category>(context);
            }
        }

        public IRepository<Author> AuthorRepository
        {
            get
            {
                return this.authorRepository ?? new GenericRepository<Author>(context);
            }
        }

        public IRepository<Order> OrderRepository
        {
            get
            {
                return this.orderRepository ?? new GenericRepository<Order>(context);
            }
        }

        public IReadOnlyRepository<OrderStatus> OrderStatusRepository
        {
            get
            {
                return this.orderStatusRepository ?? new GenericRepository<OrderStatus>(context);
            }
        }

        public IRepository<Wishlist> WishlistRepository
        {
            get
            {
                return this.wishlistRepository ?? new GenericRepository<Wishlist>(context);
            }
        }

        public IRepository<ShoppingCart> ShoppingCartRepository
        {
            get
            {
                return this.shoppingCartRepository ?? new GenericRepository<ShoppingCart>(context);
            }
        }

        public IReadOnlyRepository<ShoppingCartStatus> ShoppingCartStatusRepository
        {
            get
            {
                return this.shoppingCartStatusRepository ?? new GenericRepository<ShoppingCartStatus>(context);
            }
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
