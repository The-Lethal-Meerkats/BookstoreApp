using BookstoreApp.Data;
using BookstoreApp.Models.Accounts;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookstoreApp.API.Identity
{
    public class BookstoreUserStore : UserStore<BookstoreUser, BookstoreRole, int, BookstoreUserLogin, BookstoreUserRole, BookstoreUserClaim>
    {
        public BookstoreUserStore(IBookstoreContext context)
            : base((BookstoreContext)context)
        { }
    }
}