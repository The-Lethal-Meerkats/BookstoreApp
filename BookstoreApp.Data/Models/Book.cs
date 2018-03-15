using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int AuthorId { get; set; }

        [Required]
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public  int CategoryId { get; set; }

        [Required]
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        

        public virtual ICollection<ShoppingCart> InShoppingCarts { get; set; }

        public virtual ICollection<Order> InOrders { get; set; }

        public virtual ICollection<Wishlist> InWishlists { get; set; }
    }
}
