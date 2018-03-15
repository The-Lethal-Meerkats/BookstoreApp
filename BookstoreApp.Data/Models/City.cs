using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        public string CityName { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
