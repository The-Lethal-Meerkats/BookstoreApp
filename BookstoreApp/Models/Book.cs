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
            this.inOrders = new HashSet<Order>();
        }
        [Key]
        public int BookID { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public virtual int AuthorID { get; set; }

        [Required]
        public virtual int CategoryID { get; set; }

        public virtual ICollection<ShoppingCart> InShoppingCarts { get; set; }

        public virtual ICollection<Order> inOrders { get; set; }

        public virtual ICollection<Wishlist> InWishlists { get; set; }
    }
}
