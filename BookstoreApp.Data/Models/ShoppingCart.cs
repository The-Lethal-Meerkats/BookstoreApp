using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoreApp.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            this.Books = new HashSet<Book>();
        }

        [Key]
        public int ShoppingCartId { get; set; }

        public int UserId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }



        [InverseProperty("ShoppingCart")]
        public virtual ShoppingCartStatus ShoppingCartStatus { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
