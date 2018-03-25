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


        public int AddBookToShoppingCart(Book book, int userId)
        {
            return this.shoppingCartService.AddBookToShoppingCart(book, userId);
        }

        public int DeleteBookFromShoppingCart(Book book, int userId)
        {
            return this.shoppingCartService.DeleteBookFromShoppingCart(book, userId);
        }

        public List<BookViewModel> ShowUserShoppingCart(int userId)
        {
            var shoppingCart = this.shoppingCartService.ShowUserShoppingCart(userId);

            return shoppingCart;
        }
    }
}
