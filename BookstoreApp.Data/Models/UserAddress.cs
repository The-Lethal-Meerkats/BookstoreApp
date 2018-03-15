using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoreApp.Models
{
    public class UserAddress
    {
        [Key]
        public int UserAddressId { get; set; }

        [Required]
        public string Street { get; set; }

        public int UserId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int CountryId { get; set; }

        [Required]
        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        public int CityId { get; set; }

        [Required]
        [ForeignKey("CityId")]
        public City City { get; set; }
    }
}
