using Microsoft.AspNet.Identity.EntityFramework;

namespace BookstoreApp.Models.Accounts
{
    public class BookstoreUser : IdentityUser<int, BookstoreUserLogin, BookstoreUserRole, BookstoreUserClaim>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }


        public int UserAddressId { get; set; }
        public virtual UserAddress UserAddress { get; set; }
    }
}
