using BookstoreApp.Models;
using BookstoreApp.Services.ViewModels;
using System.Collections.Generic;

namespace BookstoreApp.Services.Contracts
{
    public interface IWishlistService
    {
        int AddBookToWishlist(int bookId, int userId);

        int DeleteBookFromWishlist(int bookId, int userId);

        List<BookViewModel> GetUserWishlistBooks(int userId);
    }
}
