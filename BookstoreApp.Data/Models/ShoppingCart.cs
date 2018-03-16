using System.Collections.Generic;

namespace BookstoreApp.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            this.Books = new HashSet<Book>();
        }

        public int Id { get; set; }


        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int ShoppingCartStatusId { get; set; }
        public virtual ShoppingCartStatus ShoppingCartStatus { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
