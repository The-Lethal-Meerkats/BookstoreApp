using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security;

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
                var user = this.authenticationManager.User.FindFirst(c => c.Type == "UserId");
                var userId = int.Parse(user.Value);

                return userId;
            }
        }
    }


}
