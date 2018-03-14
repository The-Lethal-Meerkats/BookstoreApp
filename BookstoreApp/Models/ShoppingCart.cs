using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            this.Books = new HashSet<Book>();
        }

        [Key]
        public int ShoppingCartID { get; set; }

        [Required]
        public virtual int UserID { get; set; }

        [Required]
        public virtual int ShoppingCartStatusID { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
