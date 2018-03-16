namespace BookstoreApp.Models
{
    public class UserAddress
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
