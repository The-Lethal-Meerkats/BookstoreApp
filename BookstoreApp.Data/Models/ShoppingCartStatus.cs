using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Models
{
    public class ShoppingCartStatus
    {
        public int ShoppingCartStatusId { get; set; }

        [Required]
        public string ShoppingCartStatusDescription { get; set; }

        public int ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
