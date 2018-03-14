using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Models
{
    public class Wishlist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual int UserID { get; set; }

        [Required]
        public int BookID { get; set; }
    }
}
