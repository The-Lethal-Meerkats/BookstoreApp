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
            var userId = userContext.UserId;

            var books = shoppingCartService.ShowUserShoppingCart(userId);

            if (books == null)
            {
                books = new List<BookViewModel>();
            }

            return View(books);
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