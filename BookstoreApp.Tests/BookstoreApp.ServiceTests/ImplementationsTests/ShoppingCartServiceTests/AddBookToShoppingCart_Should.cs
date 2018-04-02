using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Models.Accounts;
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
        [TestMethod]
        public void InvokesGetByIdOnce_When_AddBookToShoppingCartIsCalledWithCorrectParams()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperStub = new Mock<IMapper>();
            var fakeUser = new BookstoreUser(){Id=1};
            var fakeBook = new Book();
            var fakeShoppingCart = new ShoppingCart(){UserId = 1};
            var fakeShoppingCarts = new List<ShoppingCart>(){fakeShoppingCart}.AsQueryable();
            var shoppingCartService = new ShoppingCartService(unitOfWorkMock.Object, mapperStub.Object);

            unitOfWorkMock.Setup(x=>x.ShoppingCartStatuses.GetById(It.IsAny<int>())).Verifiable();
            unitOfWorkMock.Setup(x => x.Users.GetById(1)).Returns(fakeUser);
            unitOfWorkMock.Setup(x => x.Books.GetById(1)).Returns(fakeBook);
            unitOfWorkMock.Setup(x => x.ShoppingCarts.All()).Returns(fakeShoppingCarts);

            shoppingCartService.AddBookToShoppingCart(1, 1);

            unitOfWorkMock.Verify(x=>x.ShoppingCartStatuses.GetById(It.IsAny<int>()),Times.Once);
        }
        [TestMethod]
        public void InvokesGetUserOnce_When_AddBookToShoppingCartIsCalledWithCorrectParams()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperStub = new Mock<IMapper>();
            var fakeUser = new BookstoreUser() { Id = 1 };
            var fakeBook = new Book();
            var fakeShoppingCart = new ShoppingCart() { UserId = 1 };
            var fakeShoppingCarts = new List<ShoppingCart>() { fakeShoppingCart }.AsQueryable();
            var shoppingCartService = new ShoppingCartService(unitOfWorkMock.Object, mapperStub.Object);

            unitOfWorkMock.Setup(x => x.ShoppingCartStatuses.GetById(It.IsAny<int>()));
            unitOfWorkMock.Setup(x => x.Users.GetById(1)).Returns(fakeUser).Verifiable();
            unitOfWorkMock.Setup(x => x.Books.GetById(1)).Returns(fakeBook);
            unitOfWorkMock.Setup(x => x.ShoppingCarts.All()).Returns(fakeShoppingCarts);

            shoppingCartService.AddBookToShoppingCart(1, 1);

            unitOfWorkMock.Verify(x => x.Users.GetById(1), Times.Once);
        }
        [TestMethod]
        public void InvokesGetBookOnce_When_AddBookToShoppingCartIsCalledWithCorrectParams()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperStub = new Mock<IMapper>();
            var fakeUser = new BookstoreUser() { Id = 1 };
            var fakeBook = new Book();
            var fakeShoppingCart = new ShoppingCart() { UserId = 1 };
            var fakeShoppingCarts = new List<ShoppingCart>() { fakeShoppingCart }.AsQueryable();
            var shoppingCartService = new ShoppingCartService(unitOfWorkMock.Object, mapperStub.Object);

            unitOfWorkMock.Setup(x => x.ShoppingCartStatuses.GetById(It.IsAny<int>()));
            unitOfWorkMock.Setup(x => x.Users.GetById(1)).Returns(fakeUser);
            unitOfWorkMock.Setup(x => x.Books.GetById(1)).Returns(fakeBook).Verifiable();
            unitOfWorkMock.Setup(x => x.ShoppingCarts.All()).Returns(fakeShoppingCarts);

            shoppingCartService.AddBookToShoppingCart(1, 1);

            unitOfWorkMock.Verify(x => x.Books.GetById(It.IsAny<int>()), Times.Once);
        }
        
        [TestMethod]
        public void InvokesSaveChangesAddOnce_When_AddBookToShoppingCartIsCalledWithCorrectParams()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperStub = new Mock<IMapper>();
            var fakeUser = new BookstoreUser() { Id = 1 };
            var fakeBook = new Book();
            var fakeShoppingCart = new ShoppingCart() { UserId = 1 };
            var fakeShoppingCarts = new List<ShoppingCart>() { fakeShoppingCart }.AsQueryable();
            var shoppingCartService = new ShoppingCartService(unitOfWorkMock.Object, mapperStub.Object);

            unitOfWorkMock.Setup(x => x.ShoppingCartStatuses.GetById(It.IsAny<int>())).Verifiable();
            unitOfWorkMock.Setup(x => x.Users.GetById(1)).Returns(fakeUser);
            unitOfWorkMock.Setup(x => x.Books.GetById(1)).Returns(fakeBook);
            unitOfWorkMock.Setup(x => x.ShoppingCarts.All()).Returns(fakeShoppingCarts);
            unitOfWorkMock.Setup(x=>x.SaveChanges()).Verifiable();

            shoppingCartService.AddBookToShoppingCart(1, 1);

            unitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once);
        }


    }
}
