using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoreApp.Models
{
    public class UserAddress
    {
        [ForeignKey("User")]
        public int UserAddressId { get; set; }

        public string Street { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public User User { get; set; }
    }
}
