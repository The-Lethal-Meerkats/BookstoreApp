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
