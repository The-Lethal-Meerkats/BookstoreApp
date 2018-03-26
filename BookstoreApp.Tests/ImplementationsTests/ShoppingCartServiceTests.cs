using System;
using AutoMapper;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Services.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookstoreApp.Tests.ImplementationsTests
{
    [TestClass]
    public class ShoppingCartServiceTests
    {
        [TestMethod]
        public void Should_NotReturnNull_When_ShoppingCartServiceCalled()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            var shoppingCartService = new ShoppingCartService(unitOfWorkMock.Object, mapperMock.Object);

            Assert.IsNotNull(shoppingCartService);
        }
    }
}
