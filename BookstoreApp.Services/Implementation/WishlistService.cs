using BookstoreApp.Data.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreApp.Services.Implementation
{
    public class WishlistService : IWishlistService
    {
        private readonly IUnitOfWork unitOfWork;

        public WishlistService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public int AddBookToWishlist(int bookId, int userId)
        {
            var wishlist = this.unitOfWork.Wishlists.GetById(userId);
            var book = this.unitOfWork.Books.GetById(bookId);

            if (wishlist == null)
            {
                return -1;
            }

            wishlist.Books.Add(book);

            return this.unitOfWork.SaveChanges();
        }

        public int DeleteBookFromWishlist(int bookId, int userId)
        {
            var wishlist = this.unitOfWork.Wishlists.GetById(userId);
            var book = this.unitOfWork.Books.GetById(bookId);

            if (wishlist == null)
            {
                return -1;
            }

            wishlist.Books.Remove(book);

            return this.unitOfWork.SaveChanges();
        }

        public ICollection<Book> GetUserWishlistBooks(int userId)
        {
            var wishlist = this.unitOfWork.Wishlists.GetById(userId);

            if(wishlist == null)
            {
                return null;
            }

            var wishlistUser = wishlist.Books.AsQueryable().ToList();

            return wishlistUser;
        }
    }
}
