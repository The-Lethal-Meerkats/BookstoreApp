﻿using BookstoreApp.Models;
using System.Collections.Generic;
using BookstoreApp.Services.ViewModels;

namespace BookstoreApp.Services.Contracts
{
    public interface IShoppingCartService
    {
        int AddBookToShoppingCart(Book book, int userId);

        int DeleteBookFromShoppingCart(Book book, int userId);

        IList<Book> ShowUserShoppingCart(int userId);

        int PlaceOrderFromShoppingCart(int userId, OrderModel orderModel);
    }
}
