using BookstoreApp.Models.Accounts;
using Microsoft.AspNet.Identity;
using System;

namespace BookstoreApp.API.Identity
{
    public class BookstoreUserManager : UserManager<BookstoreUser, int>
    {
        public BookstoreUserManager(IUserStore<BookstoreUser, int> store)
            : base(store)
        {
            // Configure validation logic for usernames
            this.UserValidator = new UserValidator<BookstoreUser, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            this.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            this.UserLockoutEnabledByDefault = true;
            this.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            this.MaxFailedAccessAttemptsBeforeLockout = 5;
        }
    }
}