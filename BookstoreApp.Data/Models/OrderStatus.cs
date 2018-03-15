using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Models
{
    public class OrderStatus
    {
        public int OrderStatusId { get; set; }

        [Required]
        public string OrderStatusDescription { get; set; }
    }
}
