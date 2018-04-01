using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BookstoreApp.Models.Accounts;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.ViewModels;

namespace BookstoreApp.API.Controllers
{
    public class WishlistController : Controller
    {
        private IWishlistService wishlistService;
        private IBookstoreUserContext userContext;

        public WishlistController(IWishlistService wishlistService, IBookstoreUserContext userContext)
        {
            this.wishlistService = wishlistService;
            this.userContext = userContext;
        }

        // GET: Wishlist
        public ActionResult WishlistBookCollection()
        {
            try
            {
                var userId = this.userContext.UserId;

                var books = wishlistService.GetUserWishlistBooks(userId);

                if (books == null)
                {
                    books = new List<BookViewModel>();
                }

                return View(books);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        public ActionResult AddToWishlist(int bookId)
        {
            try
            {
                var userId = this.userContext.UserId;

                wishlistService.AddBookToWishlist(bookId, userId);
            }
            catch (Exception)
            {
                return View("ErrorAdd");
            }

            return View("SuccessAdd");
        }

        public ActionResult DeleteFromWishlist(int bookId)
        {
            try
            {
                var userId = this.userContext.UserId;

                wishlistService.DeleteBookFromWishlist(bookId, userId);
            }
            catch (Exception)
            {
                return View("Error");
            }

            return View("SuccessDelete");
        }
    }
}