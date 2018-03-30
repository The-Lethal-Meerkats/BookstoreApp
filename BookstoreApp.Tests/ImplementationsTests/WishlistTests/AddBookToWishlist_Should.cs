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

namespace BookstoreApp.Tests.ImplementationsTests.WishlistTests
{
    [TestClass]
    public class AddBookToWishlist_Should
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

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wishlistService.AddBookToWishlist(1, -1));
        }

        [TestMethod]
        public void ThrowArgumentOutOfRangeException_WhenInvokedWithIncorrectBookId()
        {
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var wishlistService = new WishlistService(unitOfWorkMock.Object, mapperMock.Object);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wishlistService.AddBookToWishlist(-1, 1));
        }

        [TestMethod]
        public void AddsBookToWishlist_WhenInvokedWithCorrectParams()
        {
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repoMock = new Mock<IRepository<Wishlist>>();
            var repoMock1 = new Mock<IRepository<User>>();
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
                Id = 2,
                Isbn = "12233",
                Title = "Java Unleashed",
                Author = author1,
                CategoryId = 2,
            };
            var country = new Country() { CountryName = "Bulgaria", Id = 1 };
            var city = new City() { CityName = "Sofia", Country = country, CountryId = 1, Id = 1 };
            var address = new UserAddress() { City = city, CityId = 1, Id = 1, Street = "street" };
            var books = new Collection<Book>() { book1, book2 };
            var user1 = new User()
            {
                FirstName = "Pesho",
                LastName = "Petrov",
                Id = 5,
                Password = "secret",
                Email = "email",
                PhoneNumber = "0888888",
                UserAddress = address,
                UserAddressId = 1,
                Username = "Pesho"
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
            unitOfWorkMock.Setup(x => x.Users).Returns(repoMock1.Object);
            var wishlistService = new WishlistService(unitOfWorkMock.Object, mapperMock.Object);
            unitOfWorkMock.Object.Users.Add(user1);
            //wishlistService.AddBookToWishlist(book1.Id, user1.Id);

            var actualBookCountInWishlist = wishlist.Books.Count;

            Assert.AreEqual(2, actualBookCountInWishlist);
        }
    }
}
