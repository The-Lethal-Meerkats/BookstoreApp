using System;
using AutoMapper;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Services.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookstoreApp.Tests.BookstoreApp.ServiceTests.ImplementationsTests.ShoppingCartServiceTests
{
    [TestClass]
    public class RemoveBookFromShoppingCart_Should
    {
        [TestMethod]
        public void ThrowArgumentException_When_RemoveBookToShoppingCartIsCalledWithNonExistentUserId()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperStub = new Mock<IMapper>();

            var shoppingCartService = new ShoppingCartService(unitOfWorkMock.Object, mapperStub.Object);

            var validBookId = 2;
            var invalidUserId = -1;

            Assert.ThrowsException<ArgumentException>(() => shoppingCartService.RemoveBookFromShoppingCart(validBookId, invalidUserId));
        }

        [TestMethod]
        public void ThrowArgumentException_When_RemoveBookToShoppingCartIsCalledWithNonExistentBookId()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperStub = new Mock<IMapper>();

            var shoppingCartService = new ShoppingCartService(unitOfWorkMock.Object, mapperStub.Object);

            var validBookId = -1;
            var invalidUserId = 2;

            Assert.ThrowsException<ArgumentException>(() => shoppingCartService.RemoveBookFromShoppingCart(validBookId, invalidUserId));
        }

    }
}
