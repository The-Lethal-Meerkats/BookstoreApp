using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BookstoreApp.Models.Accounts;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.ViewModels;

namespace BookstoreApp.API.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IShoppingCartService shoppingCartService;
        private IBookstoreUserContext userContext;

        public ShoppingCartController(IShoppingCartService shoppingCartService, IBookstoreUserContext userContext)
        {
            this.shoppingCartService = shoppingCartService;
            this.userContext = userContext;
        }

        public ActionResult ShoppingCartBookCollection()
        {
            try
            {
                var userId = userContext.UserId;

                var books = this.shoppingCartService.ShowUserShoppingCart(userId);

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

        public ActionResult AddBookToShoppingCart(int bookId)
        {
            try
            {
                var userId = userContext.UserId;
                
                shoppingCartService.AddBookToShoppingCart(bookId, userId);
            }
            catch (Exception)
            {                
                return View("ErrorAdd");
            }

            return View("SuccessAdd");
        }

        public ActionResult DeleteBookToShoppingCart(int bookId)
        {
            try
            {
                var userId = userContext.UserId;

                shoppingCartService.RemoveBookFromShoppingCart(bookId, userId);
            }
            catch (Exception)
            {
                return View("ErrorDelete");
            }

            return View("SuccessDelete");
        }
    }
}