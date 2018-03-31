using BookstoreApp.Models;
using BookstoreApp.Models.Accounts;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BookstoreApp.Data
{
    public class BookstoreContext : IdentityDbContext<BookstoreUser, BookstoreRole, int, BookstoreUserLogin, BookstoreUserRole, BookstoreUserClaim>, IBookstoreContext 
    {
        public BookstoreContext() 
            : base("Bookstore")
        { }
        
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<BookstoreUser>()
                .Property(p => p.PasswordHash)
                .HasColumnName("Password");

            modelBuilder.Entity<BookstoreUser>().ToTable("BookstoreUsers");
            modelBuilder.Entity<BookstoreRole>().ToTable("BookstoreRoles");
            modelBuilder.Entity<BookstoreUserClaim>().ToTable("BookstoreUserClaims");
            modelBuilder.Entity<BookstoreUserRole>().ToTable("BookstoreUserRoles");
            modelBuilder.Entity<BookstoreUserLogin>().ToTable("BookstoreUserLogins");
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
