using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Models
{
    public class UserAddress
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        public virtual Country CountryId { get; set; }

        [Required]
        public virtual City CityId { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public virtual User User { get; set; }
    }
}
