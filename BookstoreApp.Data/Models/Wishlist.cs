using System.Collections.Generic;

namespace BookstoreApp.Models
{
    public class Wishlist
    {
        public Wishlist()
        {
            this.Items = new HashSet<WishlistItem>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<WishlistItem> Items { get; set; }
    }
}
