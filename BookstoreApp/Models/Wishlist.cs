using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Models
{
    public class Wishlist
    {
        public Wishlist()
        {
            this.Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public virtual int UserId { get; set; }

        [Required]
        public virtual ICollection<Book> Books { get; set; }
    }
}
