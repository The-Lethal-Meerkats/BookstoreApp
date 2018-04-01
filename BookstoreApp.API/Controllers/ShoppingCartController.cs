using System;
using System.Web.Mvc;
using BookstoreApp.Models.Accounts;
using BookstoreApp.Services.Contracts;

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
            var userId = userContext.UserId;
            var book = shoppingCartService.ShowUserShoppingCart(userId);

            return View(book);
        }

        public ActionResult AddBookToShoppingCart(int bookId)
        {
            var userId = userContext.UserId;

            try
            {
                shoppingCartService.AddBookToShoppingCart(bookId, userId);
            }
            catch (Exception ex)
            {                
                return View("ErrorAdd");
            }

            return View("SuccessAdd");
        }

        public ActionResult DeleteBookToShoppingCart(int bookId)
        {
            var userId = userContext.UserId;
            try
            {
                shoppingCartService.RemoveBookFromShoppingCart(bookId, userId);
            }
            catch (Exception ex)
            {
                return View("ErrorDelete");
            }

            return View("SuccessDelete");
        }

        public ActionResult PlaceOrderFromShoppingCart()
        {
            var userId = userContext.UserId;

            try
            {
                shoppingCartService.PlaceOrderFromShoppingCart(userId);
            }
            catch (Exception ex)
            {             
                return View("OrderFail");
            }

            return View("OrderSuccess");
        }
    }
}