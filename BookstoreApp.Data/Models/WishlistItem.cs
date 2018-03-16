namespace BookstoreApp.Models
{
    public class WishlistItem
    {
        public int Id { get; set; }

        public int WishlistId { get; set; }
        public virtual Wishlist Wishlist { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
