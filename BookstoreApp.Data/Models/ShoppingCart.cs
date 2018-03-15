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

        public int ShoppingCartId { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [InverseProperty("ShoppingCart")]
        public virtual ShoppingCartStatus ShoppingCartStatus { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
