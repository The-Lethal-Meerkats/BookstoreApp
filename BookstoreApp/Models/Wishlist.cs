using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int UserId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public virtual ICollection<Book> Books { get; set; }
    }
}
