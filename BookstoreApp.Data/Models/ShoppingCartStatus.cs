using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Models
{
    public class ShoppingCartStatus
    {
        public int Id { get; set; }

        public string ShoppingCartStatusDescription { get; set; }
    }
}
