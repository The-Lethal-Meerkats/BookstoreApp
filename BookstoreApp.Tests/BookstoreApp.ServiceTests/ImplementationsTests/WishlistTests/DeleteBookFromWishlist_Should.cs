using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Data.Repository.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Services.AutoMapper;
using BookstoreApp.Services.Implementation;
using BookstoreApp.Services.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using BookstoreApp.Models.Accounts;

namespace BookstoreApp.Tests.ImplementationsTests.WishlistTests
{
    [TestClass]
    public class DeleteBookFromWishlist_Should
    {
        [ClassInitialize]
        public static void InitilizeAutomapper(TestContext context)
        {
            AutomapperConfig.Reset();
            AutomapperConfig.Initialize();
        }


        [TestMethod]
        public void ThrowArgumentOutOfRangeException_WhenInvokedWithIncorrectUserId()
        {
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var wishlistService = new WishlistService(unitOfWorkMock.Object, mapperMock.Object);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wishlistService.DeleteBookFromWishlist(1, -1));
        }

        [TestMethod]
        public void ThrowArgumentOutOfRangeException_WhenInvokedWithIncorrectBookId()
        {
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var wishlistService = new WishlistService(unitOfWorkMock.Object, mapperMock.Object);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wishlistService.DeleteBookFromWishlist(-1, 1));
        }

        [TestMethod]
        public void DeleteBookFromWishlist_WhenInvokedWithCorrectParams()
        {
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var repoMock = new Mock<IRepository<Wishlist>>();

            var author1 = new Author { Id = 1, AuthorName = "Author1" };
            var book1 = new Book()
            {
                Id = 1,
                Isbn = "123",
                Title = "C# Unleashed",
                Author = author1,
                CategoryId = 1,
            };
            var book2 = new Book()
            {
                Id = 1,
                Isbn = "12233",
                Title = "Java Unleashed",
                Author = author1,
                CategoryId = 2,
            };
            var books = new Collection<Book>() { book1, book2 };
            var user1 = new BookstoreUser()
            {
                FirstName = "Pesho",
                LastName = "Petrov",
                Id = 2,
                PasswordHash = "secret",
                Email = "email",
                PhoneNumber = "0888888",
                UserAddress = "asd",
                UserName = "Pesho"
            };
            var wishlist = new Wishlist()
            {
                Books = books,
                Id = 1,
                User = user1,
                UserId = 2
            };
            var wishlists = new List<Wishlist>() { wishlist };

            mapperMock.Setup(x =>
                    x.Map<List<WishlistViewModel>>(It.IsAny<List<Wishlist>>()))
                .Returns(new List<WishlistViewModel>());

            mapperMock.Setup(x =>
                    x.Map<List<BookViewModel>>(It.IsAny<List<Book>>()))
                .Returns(new List<BookViewModel>());

            repoMock.Setup(x => x.All()).Returns(wishlists.AsQueryable);

            unitOfWorkMock.Setup(x => x.Wishlists).Returns(repoMock.Object);
            unitOfWorkMock.Setup(x => x.Books.GetById(1)).Returns(book1);
            unitOfWorkMock.Setup(x => x.Users.GetById(2)).Returns(user1);

            var wishlistService = new WishlistService(unitOfWorkMock.Object, mapperMock.Object);

            wishlistService.DeleteBookFromWishlist(book1.Id, user1.Id);

            var actualBookCountInWishlist = wishlist.Books.Count;

            Assert.AreEqual(1, actualBookCountInWishlist);
        }
    }
}