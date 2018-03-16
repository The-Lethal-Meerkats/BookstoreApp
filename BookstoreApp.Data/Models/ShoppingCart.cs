using System.Collections.Generic;

namespace BookstoreApp.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            this.Items = new HashSet<ShoppingCartItem>();
        }

        public int Id { get; set; }


        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int ShoppingCartStatusId { get; set; }
        public virtual ShoppingCartStatus ShoppingCartStatus { get; set; }

        public virtual ICollection<ShoppingCartItem> Items { get; set; }
    }
}
