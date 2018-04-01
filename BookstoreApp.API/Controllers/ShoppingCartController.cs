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
    public class ShoppingCartController : Controller
    {
        private IShoppingCartService shoppingCartService;
        private IAuthenticationManager authenticationManager;
        private IBookstoreUserContext userContext;

        public ShoppingCartController(IShoppingCartService shoppingCartService, IAuthenticationManager authenticationManager, IBookstoreUserContext userContext)
        {
            this.shoppingCartService = shoppingCartService;
            this.authenticationManager = authenticationManager;
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
                //TODO: Unsuccesful view
                return View();
            }

            //TODO: Succesful view
            return View();

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
                //TODO: Unsuccesful view
                return View();
            }

            //TODO: Succesful view
            return View();

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
                //TODO: Unsuccesful view
                return View();
            }

            return View();
        }
    }
}