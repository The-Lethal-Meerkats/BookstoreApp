using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
