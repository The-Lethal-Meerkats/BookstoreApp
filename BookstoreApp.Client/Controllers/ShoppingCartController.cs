using AutoMapper;
using BookstoreApp.Models;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.ViewModels;
using System.Collections.Generic;

namespace BookstoreApp.Client.Controllers
{
    public class ShoppingCartController
    {
        private readonly IShoppingCartService shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService, IMapper mapper)
        {
            this.shoppingCartService = shoppingCartService;
        }

        public int AddBookToShoppingCart(int bookId, int userId)
        {
            return this.shoppingCartService.AddBookToShoppingCart(bookId, userId);
        }

        public int DeleteBookFromShoppingCart(int bookId, int userId)
        {
            return this.shoppingCartService.RemoveBookFromShoppingCart(bookId, userId);
        }

        public int PlaceOrderFromShoppingCart(int userId)
        {
            return this.shoppingCartService.PlaceOrderFromShoppingCart(userId);
        }

        public List<BookViewModel> ShowUserShoppingCart(int userId)
        {
            var shoppingCart = this.shoppingCartService.ShowUserShoppingCart(userId);

            return shoppingCart;
        }
    }
}
