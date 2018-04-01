using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using BookstoreApp.Models.Accounts;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookstoreApp.API.Identity
{
    public class BookstoreSignInManager : SignInManager<BookstoreUser, int>
    {
        public BookstoreSignInManager(BookstoreUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(BookstoreUser user)
        {
            return user.GenerateUserIdentityAsync((BookstoreUserManager)UserManager);
        }
    }
}
