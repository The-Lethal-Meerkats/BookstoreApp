using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
