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

        [Key]
        public int BookId { get; set; }

        [Required]
        public string Isbn { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public virtual int AuthorId { get; set; }

        [Required]
        public virtual int CategoryId { get; set; }

        public virtual ICollection<ShoppingCart> InShoppingCarts { get; set; }

        public virtual ICollection<Order> InOrders { get; set; }

        public virtual ICollection<Wishlist> InWishlists { get; set; }
    }
}
