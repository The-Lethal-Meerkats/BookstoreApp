﻿using BookstoreApp.Models.Accounts;
using System;
using System.Collections.Generic;

namespace BookstoreApp.Models
{
    public class Order
    {
        public Order()
        {
            this.Books = new HashSet<Book>();
        }

        public int Id { get; set; }       

        public DateTime? ReceivedOrderTime { get; set; }

        public DateTime? OrderCompletedTime { get; set; }

        public string PhoneNumber { get; set; }

        public string DeliveryAddress { get; set; }


        public int UserId { get; set; }
        public virtual BookstoreUser User { get; set; }

        public int OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }       

        public virtual ICollection<Book> Books { get; set; }   
    }
}
