﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart()
                {
                    User = user
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

        public int PlaceOrderFromShoppingCart(int userId)
        {
            var shoppingCart = this.unitOfWork.ShoppingCarts
                .All()
                .Where(sc => sc.UserId == userId)
                .Include(sci => sci.Books)
                .FirstOrDefault();

            if (shoppingCart == null)
            {
                return -1;
            }

            throw new NotImplementedException();
        }

        public List<BookViewModel> ShowUserShoppingCart(int userId)
        {
            var shoppingCart = this.unitOfWork.ShoppingCarts
                .All()
                .Where(sc => sc.UserId == userId)
                .FirstOrDefault();

            var model = shoppingCart.Books
                .AsQueryable()
                .ProjectTo<BookViewModel>()
                .ToList();

            return model;
        }

        private Book GetBook(int bookId)
        {
            var book = this.unitOfWork.Books.GetById(bookId);

            return book;
        }

        private User GetUser(int userId)
        {
            var user = this.unitOfWork.Users.GetById(userId);

            return user;
        }
    }
}
