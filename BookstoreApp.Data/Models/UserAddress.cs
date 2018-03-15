namespace BookstoreApp.Models
{
    public class UserAddress
    {
        public int UserAddressId { get; set; }

        public string Street { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
