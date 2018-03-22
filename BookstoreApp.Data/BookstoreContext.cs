using BookstoreApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BookstoreApp.Data
{
    public class BookstoreContext : DbContext, IBookstoreContext
    {
        public BookstoreContext() 
            : base("Bookstore")
        { }

        public IDbSet<User> Users { get; set; }
        public IDbSet<UserAddress> UserAddresses { get; set; }
        public IDbSet<Country> Countries { get; set; }
        public IDbSet<City> Cities { get; set; }

        public IDbSet<Wishlist> Wishlists { get; set; }
        
        public IDbSet<Book> Books { get; set; }
        public IDbSet<BookImage> BookImages { get; set; }

        public IDbSet<Author> Authors { get; set; }
        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Order> Orders { get; set; }
        public IDbSet<OrderStatus> OrderStatuses { get; set; }

        public IDbSet<ShoppingCart> ShoppingCarts { get; set; }
        public IDbSet<ShoppingCartStatus> ShoppingCartStatuses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
