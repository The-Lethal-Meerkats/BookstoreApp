using BookstoreApp.Models;
using System.Collections.Generic;
using BookstoreApp.Services.ViewModels;

namespace BookstoreApp.Services.Contracts
{
    public interface IShoppingCartService
    {
        int AddBookToShoppingCart(int bookId, int userId);

        int RemoveBookFromShoppingCart(int bookId, int userId);

        List<BookViewModel> ShowUserShoppingCart(int userId);

        int PlaceOrderFromShoppingCart(int userId);
    }
}
