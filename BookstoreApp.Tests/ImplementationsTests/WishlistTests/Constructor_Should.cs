using System;
using AutoMapper;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Services.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookstoreApp.Tests.ImplementationsTests
{
    [TestClass]
    public class WishlistServiceTests
    {
        [TestMethod]
        public void NotReturnNull_When_WishlistServiceCalled()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            var wishlistService = new WishlistService(unitOfWorkMock.Object, mapperMock.Object);

            Assert.IsNotNull(wishlistService);
        }
    }
}
