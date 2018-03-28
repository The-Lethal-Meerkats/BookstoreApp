﻿using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreApp.Services.Implementation
{
    public class WishlistService : IWishlistService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public WishlistService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public int AddBookToWishlist(Book book, int userId)
        {
            if (book == null) 
            {
                throw new ArgumentNullException();
            }

            if (userId <= 1)
            {
                throw new ArgumentException();
            }

            var wishlist = this.unitOfWork.Wishlists
              .All()
              .Where(w => w.UserId == userId)
              .FirstOrDefault();

            if (wishlist == null)
            {
                wishlist = new Wishlist()
                {
                    UserId = userId
                };
            }

            wishlist.Books.Add(book);
            return this.unitOfWork.SaveChanges();
        }

        public int DeleteBookFromWishlist(Book book, int userId)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }

            if (userId <= 1)
            {
                throw new ArgumentException();
            }

            var wishlist = this.unitOfWork.Wishlists
              .All()
              .Where(w => w.UserId == userId)
              .FirstOrDefault();

            if (wishlist == null)
            {
                return -1;
            }

            wishlist.Books.Remove(book);
            return this.unitOfWork.SaveChanges();
        }

        public List<BookViewModel> GetUserWishlistBooks(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var wishlist = this.unitOfWork.Wishlists
               .All()
               .Where(w => w.UserId == userId)
               .FirstOrDefault();

            if (wishlist == null)
            {
                return null;
            }

            var booksModel = wishlist.Books
                .AsQueryable()
                .ProjectTo<BookViewModel>()
                .ToList();

            return booksModel;
        }
    }
}
