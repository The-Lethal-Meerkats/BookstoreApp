using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public int BookId { get; set; }

        [Required]
        public string Isbn { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        [Required]
        public int CategoryId { get; set; }      
        public virtual Category Category { get; set; }       

        public virtual ICollection<ShoppingCart> InShoppingCarts { get; set; }

        public virtual ICollection<Order> InOrders { get; set; }

        public virtual ICollection<Wishlist> InWishlists { get; set; }
    }
}
