using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookstoreApp.Models.Accounts
{
    public class BookstoreUser : IdentityUser<int, BookstoreUserLogin, BookstoreUserRole, BookstoreUserClaim>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }


        public int? UserAddressId { get; set; }
        public virtual UserAddress UserAddress { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<BookstoreUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
