using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        public string AuthorName { get; set; }
    }
}
