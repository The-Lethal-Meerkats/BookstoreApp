using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Models.Accounts;
using BookstoreApp.Services.AutoMapper;
using BookstoreApp.Services.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookstoreApp.Tests.BookstoreApp.ServiceTests.ImplementationsTests.ShoppingCartServiceTests
{
    [TestClass]
    public class ShowUserShoppingCart
    {
        [ClassInitialize]
        public static void InitilizeAutomapper(TestContext context)
        {
            AutomapperConfig.Reset();
            AutomapperConfig.Initialize();
        }
        [TestMethod]
        public void ThrowArgumentException_When_RemoveBookToShoppingCartIsCalledWithNonExistentUserId()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperStub = new Mock<IMapper>();

            var shoppingCartService = new ShoppingCartService(unitOfWorkMock.Object, mapperStub.Object);

            var invalidUserId = -1;

            var result = shoppingCartService.ShowUserShoppingCart(invalidUserId);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void InvokesGetShoppingCartOnce_When_ShowUserShoppingCartIsCalledWithCorrectParams()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperStub = new Mock<IMapper>();
            var fakeUser = new BookstoreUser() { Id = 1 };
            var fakeBook = new Book();
            var fakeShoppingCart = new ShoppingCart() { UserId = 1 };
            var fakeShoppingCarts = new List<ShoppingCart>() { fakeShoppingCart }.AsQueryable();
            var shoppingCartService = new ShoppingCartService(unitOfWorkMock.Object, mapperStub.Object);


            unitOfWorkMock.Setup(x => x.Users.GetById(1)).Returns(fakeUser);
            unitOfWorkMock.Setup(x => x.Books.GetById(1)).Returns(fakeBook);
            unitOfWorkMock.Setup(x => x.ShoppingCarts.All()).Returns(fakeShoppingCarts).Verifiable();

            shoppingCartService.ShowUserShoppingCart(1);

            unitOfWorkMock.Verify(x => x.ShoppingCarts.All(), Times.Once);
        }
    }
}
