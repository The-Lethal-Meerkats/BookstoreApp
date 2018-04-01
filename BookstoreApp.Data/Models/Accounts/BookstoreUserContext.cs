using Microsoft.Owin.Security;
using System;
using System.Security.Claims;

namespace BookstoreApp.Models.Accounts
{
    public class BookstoreUserContext : IBookstoreUserContext
    {
        private IAuthenticationManager authenticationManager;

        public BookstoreUserContext(IAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }

        public int UserId
        {
            get
            {
                var userId = this.authenticationManager.User.FindFirst(c => c.Type == "UserId");
                if (!string.IsNullOrEmpty(userId.Value))
                {
                    return int.Parse(userId.Value);
                }

                throw new ArgumentNullException();
            }
        }
    }


}
