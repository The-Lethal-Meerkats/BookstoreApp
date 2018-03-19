using BookstoreApp.Models;
using System.Collections.Generic;

namespace BookstoreApp.Services.Contracts
{
    public interface IShoppingCartService
    {
        int AddBookToShoppingCart();

        int DeleteBookFromShoppingCart(int id);

        IList<ICollection<Book>> ShowUserShoppingCart(int userId);

        int PlaceOrderFromShoppingCart(int shoppingCartId);
    }
}
