using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required]
        public string AuthorName { get; set; }
    }
}
