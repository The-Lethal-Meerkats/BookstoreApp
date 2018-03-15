using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoreApp.Models
{
    public class ShoppingCartStatus
    {
        [ForeignKey("ShoppingCart")]
        public int ShoppingCartStatusId { get; set; }

        [Required]
        public string ShoppingCartStatusDescription { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
