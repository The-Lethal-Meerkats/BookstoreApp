using BookstoreApp.Models;
using BookstoreApp.Services.ViewModels;
using System.Collections.Generic;

namespace BookstoreApp.Services.Contracts
{
    public interface IWishlistService
    {
        int AddBookToWishlist(Book book, int userId);

        int DeleteBookFromWishlist(Book book, int userId);

        List<BookViewModel> GetUserWishlistBooks(int userId);
    }
}
