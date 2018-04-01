using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using BookstoreApp.Models.Accounts;

namespace BookstoreApp.API.Identity
{
    public class BookstoreSignInManager : SignInManager<BookstoreUser, int>
    {
        public BookstoreSignInManager(BookstoreUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        { }
    }
}
