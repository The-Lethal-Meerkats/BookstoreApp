using System;
using BookstoreApp.Data;
using BookstoreApp.DAL.Repository;
using BookstoreApp.Models;

namespace BookstoreApp.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly BookstoreContext context = new BookstoreContext();

        private readonly GenericRepository<User> userRepository;

        private readonly GenericRepository<UserAddress> userAddressRepository;
        private readonly GenericRepository<City> cityRepository;
        private readonly GenericRepository<Country> countryRepository;

        private readonly GenericRepository<Book> bookRepository;
        private readonly GenericRepository<Author> authorRepository;
        private readonly GenericRepository<Category> categoryRepository;

        private readonly GenericRepository<Order> orderRepository;
        private readonly GenericRepository<OrderStatus> orderStatusRepository;

        private readonly GenericRepository<Wishlist> wishlistRepository;

        private readonly GenericRepository<ShoppingCart> shoppingCartRepository;
        private readonly GenericRepository<ShoppingCartStatus> shoppingCartStatusRepository;

        private bool disposed = false;

        public GenericRepository<User> UserRepository
        {
            get
            {
                return this.userRepository ?? new GenericRepository<User>(context);
            }
        }
        public GenericRepository<UserAddress> UserAddressRepository
        {
            get
            {
                return this.userAddressRepository ?? new GenericRepository<UserAddress>(context);
            }
        }
        public GenericRepository<City> CityRepository
        {
            get
            {
                return this.cityRepository ?? new GenericRepository<City>(context);
            }
        }
        public GenericRepository<Country> CountryRepository
        {
            get
            {
                return this.countryRepository ?? new GenericRepository<Country>(context);
            }
        }

        public GenericRepository<Book> BookRepository
        {
            get
            {
                return this.bookRepository ?? new GenericRepository<Book>(context);
            }
        }
        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                return this.categoryRepository ?? new GenericRepository<Category>(context);
            }
        }
        public GenericRepository<Author> AuthorRepository
        {
            get
            {
                return this.authorRepository ?? new GenericRepository<Author>(context);
            }
        }
        public GenericRepository<Order> OrderRepository
        {
            get
            {
                return this.orderRepository ?? new GenericRepository<Order>(context);
            }
        }
        public GenericRepository<OrderStatus> OrderStatusRepository
        {
            get
            {
                return this.orderStatusRepository ?? new GenericRepository<OrderStatus>(context);
            }
        }

        public GenericRepository<Wishlist> WishlistRepository
        {
            get
            {
                return this.wishlistRepository ?? new GenericRepository<Wishlist>(context);
            }
        }

        public GenericRepository<ShoppingCart> ShoppingCartRepository
        {
            get
            {
                return this.shoppingCartRepository ?? new GenericRepository<ShoppingCart>(context);
            }
        }

        public GenericRepository<ShoppingCartStatus> ShoppingCartStatusRepository
        {
            get
            {
                return this.shoppingCartStatusRepository ?? new GenericRepository<ShoppingCartStatus>(context);
            }
        }

        public void Save()
        {
            context.SaveChanges();
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
