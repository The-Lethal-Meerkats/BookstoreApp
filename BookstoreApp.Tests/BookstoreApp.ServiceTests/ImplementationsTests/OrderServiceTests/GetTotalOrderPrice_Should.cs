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

namespace BookstoreApp.Tests.ImplementationsTests.OrderServiceTests
{
    [TestClass]
    public class GetTotalOrderPrice_Should
    {
        [ClassInitialize]
        public static void InitilizeAutomapper(TestContext context)
        {
            AutomapperConfig.Reset();
            AutomapperConfig.Initialize();
        }

        [TestMethod]
        public void ReturnTotalOrderPrice_WhenInvokedWithCorrectOrderId()
        {
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            

            var author1 = new Author { Id = 1, AuthorName = "Author1" };
            var book1 = new Book()
            {
                Id = 1,
                Isbn = "123",
                Title = "C# Unleashed",
                Author = author1,
                Price = 10,
                CategoryId = 1               
            };

            var book2 = new Book()
            {
                Id = 2,
                Isbn = "457123",
                Title = "Java Unleashed",
                Author = author1,
                Price = 30,
                CategoryId = 1
            };

            var country = new Country() { CountryName = "Bulgaria", Id = 1 };
            var city = new City() { CityName = "Sofia", Country = country, CountryId = 1, Id = 1 };
            var address = new UserAddress() { City = city, CityId = 1, Id = 1, Street = "street" };
            var orderStatus = new OrderStatus() { Id = 1, OrderStatusDescription = "Status" };
            var books = new Collection<Book>() { book1, book2 };

            var user1 = new User()
            {
                FirstName = "Pesho",
                LastName = "Petrov",
                Id = 2,
                Password = "secret",
                Email = "email",
                PhoneNumber = "0888888",
                UserAddress = address,
                UserAddressId = 1,
                Username = "Pesho"
            };

            var order1 = new Order()
            {
                Books = books,
                DeliveryAddress = "address",
                Id = 100,
                OrderStatusId = 1,
                OrderStatus = orderStatus,
                PhoneNumber = user1.PhoneNumber,
                UserId = 1,
                User = user1,
                OrderCompletedTime = null,
                ReceivedOrderTime = null
            };

            

            mapperMock.Setup(x => x.Map<List<OrderViewModel>>(It.IsAny<List<Order>>()))
                    .Returns(new List<OrderViewModel>());

            
            
            unitOfWorkMock.Setup(x => x.Orders.GetById(100)).Returns(order1);

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object);
            

            var orderId = 100;

            var sut = orderService.GetTotalOrderPrice(orderId);

            Assert.AreEqual(40, sut);
        }

        [TestMethod]
        public void ThrowOutOfRangeException_WhenGivenInvalidOrderId()
        {
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object);

            var orderId = -1;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => orderService.GetTotalOrderPrice(orderId));
        }

        [TestMethod]
        public void ThrowNullException_WhenOrderIsNull()
        {
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object);

            int orderId = 100;
            Order order1 = null;

            unitOfWorkMock.Setup(x => x.Orders.GetById(orderId)).Returns(order1);

            Assert.ThrowsException<ArgumentNullException>(() => orderService.GetTotalOrderPrice(orderId));

        }
    }
}
