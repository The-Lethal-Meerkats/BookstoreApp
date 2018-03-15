using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoreApp.Models
{
    public class UserAddress
    {
        [Key]
        public int UserAddressId { get; set; }

        public string Street { get; set; }


        public int CountryId { get; set; }
        public virtual Country Country { get; set; }


        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
