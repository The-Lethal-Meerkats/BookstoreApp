using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

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
            if (bookId < 1)
            {
                throw new ArgumentException("Invalid bookId");
            }
            if (userId < 1)
            {
                throw new ArgumentException("Invalid userId");
            }

            var user = this.GetUser(userId);
            var bookToAdd = this.GetBook(bookId);

            var shoppingCart = GetShoppingCart(userId);

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
            if (bookId < 1)
            {
                throw new ArgumentException("Invalid bookId");
            }
            if (userId < 1)
            {
                throw new ArgumentException("Invalid userId");
            }

            var bookToRemove = this.GetBook(bookId);
            var user = this.GetUser(userId);

            var shoppingCart = GetShoppingCart(userId);

            shoppingCart.Books.Remove(bookToRemove);
            this.unitOfWork.ShoppingCarts.AddOrUpdate(sc => sc.Id, shoppingCart);

            return this.unitOfWork.SaveChanges();
        }

        public int PlaceOrderFromShoppingCart(int userId)
        {
            if (userId < 1)
            {
                throw new ArgumentException("Invalid userId");
            }

            var user = this.GetUser(userId);

            var shoppingCart = GetShoppingCart(userId);

            string deliveryAddress = this.BuildAddress(shoppingCart.User.UserAddress);

            var orderToPlace = new Order()
            {
                Books = shoppingCart.Books,
                DeliveryAddress = deliveryAddress,
                OrderStatusId = 1,
                PhoneNumber = shoppingCart.User.PhoneNumber,
                UserId = userId
            };

            this.unitOfWork.Orders.Add(orderToPlace);
            return this.unitOfWork.SaveChanges();
        }

        public List<BookViewModel> ShowUserShoppingCart(int userId)
        {
            if (userId < 1)
            {
                throw new ArgumentException("Invalid userId");
            }
            var user = this.GetUser(userId);

            var shoppingCart = GetShoppingCart(userId);

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
                throw new ArgumentException("Invalid userId");
            }

            var user = this.GetUser(userId);


            var shoppingCart = GetShoppingCart(userId);

            decimal totalPrice = 0;

            foreach (var book in shoppingCart.Books)
            {
                totalPrice += book.Price;
            }

            return totalPrice;
        }

        private Book GetBook(int bookId)
        {
            if (bookId < 1)
            {
                throw new ArgumentException("Invalid userId");
            }

            var book = this.unitOfWork.Books.GetById(bookId);

            if (book == null)
            {
                throw new ArgumentNullException("No existing book with such ID");
            }

            return book;
        }

        private User GetUser(int userId)
        {
            if (userId < 1)
            {
                throw new ArgumentException("Invalid userId");
            }

            var user = this.unitOfWork.Users.GetById(userId);

            if (user == null)
            {
                throw new ArgumentNullException("No existing user with such ID");
            }

            return user;
        }

        private ShoppingCart GetShoppingCart(int userId)
        {
            if (userId < 1)
            {
                throw new ArgumentException("Invalid userId");
            }

            var shoppingCart = this.unitOfWork.ShoppingCarts
                .All()
                .Where(or => or.UserId == userId)
                .FirstOrDefault();

            if (shoppingCart == null)
            {
                throw new ArgumentNullException("No existing user with such ID");
            }

            return shoppingCart;
        }
        private string BuildAddress(UserAddress userAddress)
        {
            var addressToBuild = new
            {
                Street = userAddress.Street,
                City = userAddress.City.CityName,
                Country = userAddress.City.Country.CountryName
            };

            string address = JsonConvert.SerializeObject(addressToBuild);

            return address;
        }
    }
}
