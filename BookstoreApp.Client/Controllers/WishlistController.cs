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


        public int AddBookToWishlist(Book book, int userId)
        {
            return this.wishlistService.AddBookToWishlist(book, userId);
        }

        public int DeleteBookFromWishlist(Book book, int userId)
        {
            return this.wishlistService.DeleteBookFromWishlist(book, userId);
        }

        public List<BookViewModel> GetUserWishlistBooks(int userId)
        {
            var wishlist = this.wishlistService.GetUserWishlistBooks(userId);

            return wishlist;
        }
    }
}
