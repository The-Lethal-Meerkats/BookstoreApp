using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Models
{
    public class Order
    {
        public Order()
        {
                this.Books = new HashSet<Book>();
        }


        [Key]
        public int OrderID { get; set; }

        [Required]
        public virtual int UserID { get; set; }

        [Required]
        public virtual int UserAddressID { get; set; }

        [Required]
        public  DateTime ReceivedOrderTime { get; set; }

        ///Optional
        public DateTime? OrderCompletedTime { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public virtual int OrderStatusID { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        
    }
}
