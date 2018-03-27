using System;
using AutoMapper;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Services.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookstoreApp.Tests.ImplementationsTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void NotReturnNull_When_OrderServiceCalled()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object);

            Assert.IsNotNull(orderService);
        }
    }
}
