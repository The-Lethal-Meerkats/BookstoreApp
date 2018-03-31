using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using BookstoreApp.Models.Accounts;
using BookstoreApp.Data;

namespace BookstoreApp.API
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class BookstoreUserManager : UserManager<BookstoreUser, int>
    {
        public BookstoreUserManager(IUserStore<BookstoreUser, int> store)
            : base(store)
        {
        }

        public static BookstoreUserManager Create(IdentityFactoryOptions<BookstoreUserManager> options, IOwinContext context) 
        {
            var manager = new BookstoreUserManager(new UserStore<BookstoreUser, BookstoreRole, int, BookstoreUserLogin, BookstoreUserRole, BookstoreUserClaim>(context.Get<BookstoreContext>()));
            
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<BookstoreUser, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
           
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class BookstoreSignInManager : SignInManager<BookstoreUser, int>
    {
        public BookstoreSignInManager(BookstoreUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(BookstoreUser user)
        {
            return user.GenerateUserIdentityAsync((BookstoreUserManager) UserManager);
        }

        public static BookstoreSignInManager Create(IdentityFactoryOptions<BookstoreSignInManager> options, IOwinContext context)
        {
            return new BookstoreSignInManager(context.GetUserManager<BookstoreUserManager>(), context.Authentication);
        }
    }
}
