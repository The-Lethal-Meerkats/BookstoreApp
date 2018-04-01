using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookstoreApp.Models.Accounts;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.Implementation;
using Microsoft.Owin.Security;

namespace BookstoreApp.API.Controllers
{
    public class WishlistController : Controller
    {
        private IWishlistService wishlistService;
        private IAuthenticationManager authenticationManager;
        private IBookstoreUserContext userContext;

        public WishlistController(IWishlistService wishlistService, IAuthenticationManager authenticationManager, IBookstoreUserContext userContext)
        {
            this.wishlistService = wishlistService;
            this.authenticationManager = authenticationManager;
            this.userContext = userContext;
        }


        // GET: Wishlist
        public ActionResult WishlistBookCollection()
        {
            
            var userId = this.userContext.UserId;
            var books = wishlistService.GetUserWishlistBooks(userId);

            return View(books);
        }

        public ActionResult AddToWishlist(int bookId)
        {

            var userId = this.userContext.UserId;
            try
            {
                wishlistService.AddBookToWishlist(bookId, userId);
            }
            catch (Exception ex)
            {
                return View("ErrorAdd");
            }

            return View("SuccessAdd");
        }

        public ActionResult DeleteFromWishlist(int bookId)
        {
            var userId = this.userContext.UserId;
            try
            {
                wishlistService.DeleteBookFromWishlist(bookId, userId);
            }
            catch (Exception ex)
            {
                //TODO : Add unsuccessful result
                return View();
            }

            //TODO: Add success view 
            return View("SuccessDelete");
        }
    }
}