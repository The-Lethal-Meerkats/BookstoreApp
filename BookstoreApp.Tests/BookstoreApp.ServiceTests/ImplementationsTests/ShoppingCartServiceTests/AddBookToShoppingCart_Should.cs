﻿using System;
using AutoMapper;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Services.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookstoreApp.Tests.ImplementationsTests.ShoppingCartServiceTests
{
    [TestClass]
    public class AddBookToShoppingCart_Should
    {
        [TestMethod]
        public void ThrowArgumentException_When_AddBookToShoppingCartIsCalledWithNonExistentUserId()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperStub = new Mock<IMapper>();

            var shoppingCartService = new ShoppingCartService(unitOfWorkMock.Object, mapperStub.Object);

            var validBookId = 2;
            var invalidUserId = -1;

            Assert.ThrowsException<ArgumentException>(() => shoppingCartService.AddBookToShoppingCart(validBookId,invalidUserId));
        }

        [TestMethod]
        public void ThrowArgumentException_When_AddBookToShoppingCartIsCalledWithNonExistentBookId()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperStub = new Mock<IMapper>();

            var shoppingCartService = new ShoppingCartService(unitOfWorkMock.Object, mapperStub.Object);

            var validBookId = -1;
            var invalidUserId = 2;

            Assert.ThrowsException<ArgumentException>(() => shoppingCartService.AddBookToShoppingCart(validBookId, invalidUserId));
        }

        
    }
}
