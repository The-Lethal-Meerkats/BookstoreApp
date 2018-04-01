using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.ViewModels;
using System.Collections.Generic;
using System.Linq;
using BookstoreApp.Models.Accounts;

namespace BookstoreApp.Services.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ShoppingCartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public int AddBookToShoppingCart(int bookId, int userId)
        {
            var user = this.GetUser(userId);
            var bookToAdd = this.GetBook(bookId);

            if (bookToAdd == null || user == null)
            {
                return -1;
            }

            var shoppingCart = this.unitOfWork.ShoppingCarts
              .All()
              .Where(sc => sc.UserId == userId)
              .FirstOrDefault();

            var cartStatus = this.unitOfWork.ShoppingCartStatuses
                .GetById(1);

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart()
                {
                    User = user,
                    ShoppingCartStatus = cartStatus
                };
            }

            shoppingCart.Books.Add(bookToAdd);
            this.unitOfWork.ShoppingCarts.AddOrUpdate(sc => sc.Id, shoppingCart);

            return this.unitOfWork.SaveChanges();
        }

        public int RemoveBookFromShoppingCart(int bookId, int userId)
        {
            var bookToRemove = this.GetBook(bookId);

            if (bookToRemove == null)
            {
                return -1;
            }

            var shoppingCart = this.unitOfWork.ShoppingCarts
              .All()
              .Where(sc => sc.UserId == userId)
              .FirstOrDefault();

            if (shoppingCart == null)
            {
                return -1;
            }

            shoppingCart.Books.Remove(bookToRemove);
            this.unitOfWork.ShoppingCarts.AddOrUpdate(sc => sc.Id, shoppingCart);

            return this.unitOfWork.SaveChanges();
        }

        public List<BookViewModel> ShowUserShoppingCart(int userId)
        {
            var shoppingCart = this.unitOfWork.ShoppingCarts
                .All()
                .Where(sc => sc.UserId == userId)
                .FirstOrDefault();

            if (shoppingCart == null)
            {
                return null;
            }

            var booksModel = shoppingCart.Books
                .AsQueryable()
                .ProjectTo<BookViewModel>()
                .ToList();

            return booksModel;
        }

        public decimal GetCartTotalPrice(int userId)
        {
            if (userId < 1)
            {
                throw new ArgumentOutOfRangeException("UserID has to be equal or bigger than one.");
            }

            var shoppingCart = this.unitOfWork.ShoppingCarts
                .All()
                .Where(or => or.UserId == userId)
                .FirstOrDefault();

            if (shoppingCart == null)
            {
                return -1;
            }

            decimal totalPrice = 0;

            foreach (var book in shoppingCart.Books)
            {
                totalPrice += book.Price;
            }

            return totalPrice;
        }

        private Book GetBook(int bookId)
        {
            var book = this.unitOfWork.Books.GetById(bookId);

            return book;
        }

        private BookstoreUser GetUser(int userId)
        {
            var user = this.unitOfWork.Users.GetById(userId);

            return user;
        }
    }
}
