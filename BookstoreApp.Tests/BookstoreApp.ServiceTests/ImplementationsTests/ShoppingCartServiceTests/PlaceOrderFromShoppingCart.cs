using System;
using AutoMapper;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Services.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookstoreApp.Tests.BookstoreApp.ServiceTests.ImplementationsTests.ShoppingCartServiceTests
{
    [TestClass]
    public class PlaceOrderFromShoppingCart
    {
        [TestMethod]
        public void ThrowArgumentException_When_RemoveBookToShoppingCartIsCalledWithNonExistentUserId()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperStub = new Mock<IMapper>();

            var shoppingCartService = new ShoppingCartService(unitOfWorkMock.Object, mapperStub.Object);

            
            var invalidUserId = -1;

            Assert.ThrowsException<ArgumentException>(() => shoppingCartService.PlaceOrderFromShoppingCart(invalidUserId));
        }
    }
}
