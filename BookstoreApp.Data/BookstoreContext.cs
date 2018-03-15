using BookstoreApp.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BookstoreApp.Data
{
    public class BookstoreContext : DbContext, IBookstoreContext
    {
        public BookstoreContext() : base("name=BookStore")
        {

        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Wishlist> Wishlists { get; set; }
        public IDbSet<Book> Books { get; set; }
        public IDbSet<Author> Authors { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<OrderStatus> OrderStatuses { get; set; }
        public IDbSet<ShoppingCart> ShoppingCart { get; set; }
        public IDbSet<ShoppingCartStatus> ShoppingCartStatuses { get; set; }
        public IDbSet<UserAddress> UserAddresses { get; set; }
        public IDbSet<Country> Countries { get; set; }
        public IDbSet<City> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
