using System;
using System.Collections.Generic;
using System.Linq;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.ViewModels;

namespace BookstoreApp.Services.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IUnitOfWork unitOfWork;

        public ShoppingCartService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int AddBookToShoppingCart(Book book, int userId)
        {

            var shoppingCart = this.unitOfWork.ShoppingCarts.GetById(userId);

            if (shoppingCart == null)
            {
                return -1;
            }

            shoppingCart.Books.Add(book);
            return this.unitOfWork.SaveChanges();
        }

        public int DeleteBookFromShoppingCart(Book book, int userId)
        {
            var shoppingCart = this.unitOfWork.ShoppingCarts.GetById(userId);

            if (shoppingCart == null)
            {
                return -1;
            }

            shoppingCart.Books.Remove(book);
            return this.unitOfWork.SaveChanges();
        }

        public int PlaceOrderFromShoppingCart(int userId, OrderViewModel orderModel)
        {
            var shoppingCart = this.unitOfWork.ShoppingCarts.GetById(userId);

            if (shoppingCart == null)
            {
                return -1;
            }

            var shoppingCartBooks = shoppingCart.Books.AsQueryable().ToList();

            // TODO: - OrderModel to be implemented + CreateOrder Service method to be implemented? 

            throw new NotImplementedException();
        }

        public IList<Book> ShowUserShoppingCart(int userId)
        {
            var shoppingCart = this.unitOfWork.ShoppingCarts.GetById(userId);

            if (shoppingCart == null)
            {
                throw new ArgumentException();
            }

            var shoppingCartBooks = shoppingCart.Books.AsQueryable().ToList();

            return shoppingCartBooks;
        }
    }
}
