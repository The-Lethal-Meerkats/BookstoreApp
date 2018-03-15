using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Models
{
    public class Order
    {
        public Order()
        {
            this.Books = new HashSet<Book>();
        }

        public int OrderId { get; set; }       

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public int UserAddressId { get; set; }
        public virtual UserAddress UserAddress { get; set; }

        [Required]
        public DateTime ReceivedOrderTime { get; set; }

        ///Optional
        public DateTime? OrderCompletedTime { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public int OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }       

        public virtual ICollection<Book> Books { get; set; }   
    }
}
