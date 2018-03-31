﻿using AutoMapper;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Data.Repository.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Models.Accounts;
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

            var author1 = new Author { Id = 1, AuthorName = "Author1" };
            var book1 = new Book()
            {
                Id = 1,
                Isbn = "123",
                Title = "C# Unleashed",
                Author = author1,
                CategoryId = 1
            };

            var country = new Country(){CountryName = "Bulgaria",Id = 1};
            var city = new City() {CityName = "Sofia", Country = country, CountryId = 1, Id = 1};
            var address = new UserAddress() { City = city,CityId = 1, Id = 1, Street = "street"};
            var orderStatus = new OrderStatus() {Id = 1, OrderStatusDescription = "Status"};
            var books = new Collection<Book>()
            {
                book1
            };

            var user1 = new BookstoreUser()
            {
                FirstName = "Pesho",
                LastName = "Petrov",
                Id = 2,
                Password = "secret",
                Email = "email",
                PhoneNumber = "0888888",
                UserAddress = address,
                UserAddressId = 1,
                UserName = "Pesho"                
            };

            var orders = new List<Order>()
            {
                new Order
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
                },
                new Order
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
                }
            };

            mapperMock.Setup(x => x.Map<List<OrderViewModel>>(It.IsAny<List<Order>>()))
                    .Returns(new List<OrderViewModel>());

            repoMock.Setup(r => r.All()).Returns(orders.AsQueryable());
            unitOfWorkMock.Setup(u => u.Orders).Returns(repoMock.Object);

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object);

            var sut = orderService.GetUserOrders(1);

            Assert.AreEqual(2, sut.Count);
        }

        [TestMethod]
        public void ThrowOutOfRangeException_WhenGivenInvalidParams()
        {
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var repoMock = new Mock<IRepository<Order>>();

            var author1 = new Author { Id = 1, AuthorName = "Author1" };
            var book1 = new Book()
            {
                Id = 1,
                Isbn = "123",
                Title = "C# Unleashed",
                Author = author1,
                CategoryId = 1
            };

            var country = new Country() { CountryName = "Bulgaria", Id = 1 };
            var city = new City() { CityName = "Sofia", Country = country, CountryId = 1, Id = 1 };
            var address = new UserAddress() { City = city, CityId = 1, Id = 1, Street = "street" };
            var orderStatus = new OrderStatus() { Id = 1, OrderStatusDescription = "Status" };
            var books = new Collection<Book>()
            {
                book1
            };

            var user1 = new BookstoreUser()
            {
                FirstName = "Pesho",
                LastName = "Petrov",
                Id = 2,
                Password = "secret",
                Email = "email",
                PhoneNumber = "0888888",
                UserAddress = address,
                UserAddressId = 1,
                UserName = "Pesho"
            };

            IList<Order> orders = new List<Order>()
            {
                new Order
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
                },
                new Order
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
                }
            };

            mapperMock.Setup(x => x.Map<List<OrderViewModel>>(It.IsAny<List<Order>>()))
                    .Returns(new List<OrderViewModel>());

            repoMock.Setup(r => r.All()).Returns(orders.AsQueryable());
            unitOfWorkMock.Setup(u => u.Orders).Returns(repoMock.Object);

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object);

           
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => orderService.GetUserOrders(-1));
        }
    }
}