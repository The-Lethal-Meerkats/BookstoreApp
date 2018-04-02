using AutoMapper;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Data.Repository.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Services.AutoMapper;
using BookstoreApp.Services.Implementation;
using BookstoreApp.Services.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BookstoreApp.Models.Accounts;

namespace BookstoreApp.Tests.ImplementationsTests.OrderServiceTests
{
    [TestClass]
    public class GetUserOrders_Should
    {
        [ClassInitialize]
        public static void InitilizeAutomapper(TestContext context)
        {
            AutomapperConfig.Reset();
            AutomapperConfig.Initialize();
        }

        [TestMethod]
        public void ReturnAllOrders_WhenInvokedWithCorrectUserId()
        {
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repoMock = new Mock<IRepository<Order>>();

            var user1 = new BookstoreUser()
            {
                Id = 2,

            };

            var orders = new List<Order>()
            {
                new Order
                {
                    UserId = 2,
                    User = user1
                  
                },
                new Order
                {
                    UserId = 2,
                    User = user1
                }
            };

            mapperMock.Setup(x => x.Map<List<OrderViewModel>>(It.IsAny<List<Order>>()))
                    .Returns(new List<OrderViewModel>());

            repoMock.Setup(r => r.All()).Returns(orders.AsQueryable());
            unitOfWorkMock.Setup(u => u.Orders).Returns(repoMock.Object);

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object);

            var sut = orderService.GetUserOrders(2);

            Assert.AreEqual(2, sut.Count);
        }

        [TestMethod]
        public void ThrowOutOfRangeException_WhenGivenInvalidParams()
        {
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object);


            Assert.ThrowsException<ArgumentOutOfRangeException>(() => orderService.GetUserOrders(-1));
        }

    }
}
