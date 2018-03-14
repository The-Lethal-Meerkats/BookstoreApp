using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoreApp.Models
{
    public class Order
    {
        public Order()
        {
            this.Books = new HashSet<Book>();
        }

        [Key]
        public int OrderId { get; set; }

        [Required]
        public virtual int UserId { get; set; }

        [Required]
        public virtual int UserAddressId { get; set; }

        [Required]
        public  DateTime ReceivedOrderTime { get; set; }

        ///Optional
        public DateTime? OrderCompletedTime { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public int OrderStatusID { get; set; }
        [Required]
        [ForeignKey("OrderStatusID")]
        public OrderStatus OrderStatus { get; set; }
        

        public virtual ICollection<Book> Books { get; set; }   
    }
}
