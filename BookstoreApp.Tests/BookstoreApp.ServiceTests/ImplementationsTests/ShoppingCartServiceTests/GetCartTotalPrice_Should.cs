using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AutoMapper;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Models.Accounts;
using BookstoreApp.Services.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookstoreApp.Tests.BookstoreApp.ServiceTests.ImplementationsTests.ShoppingCartServiceTests
{
    [TestClass]
    public class GetCartTotalPrice_Should
    {
        [TestMethod]
        public void ThrowArgumentException_When_RemoveBookToShoppingCartIsCalledWithNonExistentUserId()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperStub = new Mock<IMapper>();

            var shoppingCartService = new ShoppingCartService(unitOfWorkMock.Object, mapperStub.Object);

            var invalidUserId = -1;

            Assert.ThrowsException<ArgumentException>(() => shoppingCartService.GetCartTotalPrice(invalidUserId));
        }

        [TestMethod]
        public void ReturnCorrectValue_WhenInvokedWithCorrectParams()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperStub = new Mock<IMapper>();

            var shoppingCartService = new ShoppingCartService(unitOfWorkMock.Object, mapperStub.Object);

            var author1 = new Author { Id = 1, AuthorName = "Author1" };
            

            var books = new List<Book>
            {
                new Book { Id = 1, Isbn = "123",
                    Title = "C# Unleashed", Author = author1, CategoryId = 1,Price = 10},
                new Book { Id = 2, Isbn = "213",
                    Title = "ASP.Net Unleashed", Author = author1, CategoryId = 1,Price = 10},
                new Book { Id = 3, Isbn = "312",
                    Title = "Java Unleashed", Author = author1, CategoryId = 1, Price = 10}
            };

            
           
            var user1 = new BookstoreUser()
            {
                FirstName = "Pesho",
                LastName = "Petrov",
                Id = 2,
               
                Email = "email",
                PhoneNumber = "0888888",
                
            
                
            };
            var shoppingCartStatus = new ShoppingCartStatus()
            {
                Id =1,
                ShoppingCartStatusDescription = "test"
            };
            
            var shoppingCart = new ShoppingCart()
            {
                Books = books,
                Id = 1,
                
                UserId = 2,
                ShoppingCartStatus = shoppingCartStatus,
                ShoppingCartStatusId = shoppingCartStatus.Id

            };

            var shoppingCarts = new List<ShoppingCart>(){shoppingCart}.AsQueryable();

            unitOfWorkMock.Setup(x => x.Users.GetById(2)).Returns(user1);
            unitOfWorkMock.Setup(x => x.ShoppingCarts.All()).Returns(shoppingCarts);

            var expectedTotalPrice = 30;

            var actualTotalPrice = shoppingCartService.GetCartTotalPrice(user1.Id);

            Assert.AreEqual(expectedTotalPrice,actualTotalPrice);

        }
    }
}
