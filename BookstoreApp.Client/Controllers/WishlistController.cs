using AutoMapper;
using BookstoreApp.Models;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.ViewModels;
using System.Collections.Generic;

namespace BookstoreApp.Client.Controllers
{
    public class WishlistController
    {
        private readonly IWishlistService wishlistService;

        public WishlistController(IWishlistService wishlistService, IMapper mapper)
        {
            this.wishlistService = wishlistService;
        }


        public int AddBookToWishlist(int bookId, int userId)
        {
            return this.wishlistService.AddBookToWishlist(bookId, userId);
        }

        public int DeleteBookFromWishlist(int bookId, int userId)
        {
            return this.wishlistService.DeleteBookFromWishlist(bookId, userId);
        }

        public List<BookViewModel> GetUserWishlistBooks(int userId)
        {
            var wishlist = this.wishlistService.GetUserWishlistBooks(userId);

            return wishlist;
        }
    }
}
