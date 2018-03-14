using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Models
{
    class OrderStatus
    {
        [Key]
        public int OrderStatusID { get; set; }

        [Required]
        public string OrderStatusDescription { get; set; }
    }
}
