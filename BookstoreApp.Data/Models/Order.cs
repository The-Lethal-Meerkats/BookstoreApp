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

        public int Id { get; set; }       

        public DateTime ReceivedOrderTime { get; set; }

        public DateTime? OrderCompletedTime { get; set; }

        public string PhoneNumber { get; set; }


        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }       

        public virtual ICollection<Book> Books { get; set; }   
    }
}
