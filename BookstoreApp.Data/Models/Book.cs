using System.Collections.Generic;

namespace BookstoreApp.Models
{
    public class Book
    {
        public Book()
        {
            this.InShoppingCarts = new HashSet<ShoppingCart>();
            this.InWishlists = new HashSet<Wishlist>();
            this.InOrders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public string Isbn { get; set; }

        public string BookName { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int CategoryId { get; set; }      
        public virtual Category Category { get; set; }

        public int? BookImageId { get; set; }
        public virtual BookImage BookImage { get; set; }

        public virtual ICollection<ShoppingCart> InShoppingCarts { get; set; }
        public virtual ICollection<Order> InOrders { get; set; }
        public virtual ICollection<Wishlist> InWishlists { get; set; }

    }
}
