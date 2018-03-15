using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Models
{
    public class Country
    {
        public int CountryId { get; set; }

        [Required]
        public string CountryName { get; set; }
    }
}
