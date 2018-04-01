using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.Implementation;
using Microsoft.Owin.Security;

namespace BookstoreApp.API.Controllers
{
    public class WishlistController : Controller
    {
        private IWishlistService wishlistService;
        private IAuthenticationManager authenticationManager;

        public WishlistController(IWishlistService wishlistService, IAuthenticationManager authenticationManager)
        {
            this.wishlistService = wishlistService ?? throw new ArgumentNullException();
            this.authenticationManager = authenticationManager ?? throw new ArgumentNullException();
        }


        // GET: Wishlist
        public ActionResult WishlistBookCollection()
        {
            var user = this.authenticationManager.User.FindFirst(c => c.Type == "UserId");
            var userId = int.Parse(user.Value);
            var books = wishlistService.GetUserWishlistBooks(userId);

            return View(books);
        }

        public ActionResult AddToWishlist(int bookId)
        {          
            var user = this.authenticationManager.User.FindFirst(c => c.Type == "UserId");
            var userId = int.Parse(user.Value);

            try
            {
                wishlistService.AddBookToWishlist(bookId, userId);
            }
            catch (Exception ex)
            {
                return View("Error");
            }

            return View("Success");
        }

        public ActionResult DeleteFromWishlist(int bookId)
        {
            var user = this.authenticationManager.User.FindFirst(c => c.Type == "UserId");
            var userId = int.Parse(user.Value);
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
            return View();
        }
    }
}