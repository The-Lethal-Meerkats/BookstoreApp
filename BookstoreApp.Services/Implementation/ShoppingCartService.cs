﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.ViewModels;
using System;
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


        public int AddBookToShoppingCart(Book book, int userId)
        {
            var shoppingCart = this.unitOfWork.ShoppingCarts
              .All()
              .Where(sc => sc.UserId == userId)
              .FirstOrDefault();

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart()
                {
                    UserId = userId
                };
            }

            shoppingCart.Books.Add(book);
            return this.unitOfWork.SaveChanges();
        }

        public int DeleteBookFromShoppingCart(Book book, int userId)
        {
            var shoppingCart = this.unitOfWork
              .ShoppingCarts
              .All()
              .Where(sc => sc.UserId == userId)
              .FirstOrDefault();

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
    }
}
