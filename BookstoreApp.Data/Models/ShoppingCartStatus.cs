using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Models
{
    public class ShoppingCartStatus
    {
        [Key]
        public int ShoppingCartStatusId { get; set; }

        [Required]
        public string ShoppingCartStatusDescription { get; set; }
    }
}
