using BookstoreApp.Models;
using System.Collections.Generic;

namespace BookstoreApp.Services.Contracts
{
    public interface IWishlistService
    {
        int AddBookToWishlist(int bookId, int userId);

        int DeleteBookFromWishlist(int bookId, int userId);

        ICollection<Book> GetUserWishlistBooks(int userId);
    }
}
