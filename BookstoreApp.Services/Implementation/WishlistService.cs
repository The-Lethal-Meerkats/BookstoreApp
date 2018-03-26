using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreApp.Services.Implementation
{
    public class WishlistService : IWishlistService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public WishlistService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public int AddBookToWishlist(int bookId, int userId)
        {
            var user = this.GetUser(userId);
            var book = this.GetBook(bookId);

            if (user == null || book == null)
            {
                return -1;
            }

            var wishlist = this.unitOfWork.Wishlists
              .All()
              .Where(w => w.UserId == userId)
              .FirstOrDefault();

            if (wishlist == null)
            {
                wishlist = new Wishlist()
                {
                    User = user
                };
            }

            wishlist.Books.Add(book);
            this.unitOfWork.Wishlists.AddOrUpdate(wl => wl.Id, wishlist);

            return this.unitOfWork.SaveChanges();
        }

        public int DeleteBookFromWishlist(int bookId, int userId)
        {
            var user = this.GetUser(userId);
            var book = this.GetBook(bookId);

            if (user == null || book == null)
            {
                return -1;
            }

            var wishlist = this.unitOfWork.Wishlists
              .All()
              .Where(w => w.UserId == userId)
              .FirstOrDefault();

            if (wishlist == null)
            {
                return -1;
            }

            wishlist.Books.Remove(book);
            this.unitOfWork.Wishlists.AddOrUpdate(wl => wl.Id, wishlist);

            return this.unitOfWork.SaveChanges();
        }

        public List<BookViewModel> GetUserWishlistBooks(int userId)
        {
            var wishlist = this.unitOfWork.Wishlists
               .All()
               .Where(w => w.UserId == userId)
               .FirstOrDefault();

            if (wishlist == null)
            {
                return null;
            }

            var booksModel = wishlist.Books
                .AsQueryable()
                .ProjectTo<BookViewModel>()
                .ToList();

            return booksModel;
        }

        private Book GetBook(int bookId)
        {
            var book = this.unitOfWork.Books.GetById(bookId);

            return book;
        }

        private User GetUser(int userId)
        {
            var user = this.unitOfWork.Users.GetById(userId);

            return user;
        }
    }
}
