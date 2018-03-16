using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ItemId { get; set; }


        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
