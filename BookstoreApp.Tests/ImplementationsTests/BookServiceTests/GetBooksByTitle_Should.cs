using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Data.Repository.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Services.AutoMapper;
using BookstoreApp.Services.Implementation;
using BookstoreApp.Services.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookstoreApp.Tests.ImplementationsTests.BookServiceTests
{
    [TestClass]
    public class GetBooksByTitle_Should
    {
        [ClassInitialize]
        public static void InitilizeAutomapper(TestContext context)
        {
            AutomapperConfig.Initialize();
        }

        [TestMethod]
        public void ReturnAllBooksWithSpecifiedTitle_WhenInvokedWithCorrectParams()
        {
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repoMock = new Mock<IRepository<Book>>();

            var author1 = new Author { Id = 1, AuthorName = "Author1" };
            var author2 = new Author { Id = 2, AuthorName = "Author2" };
            var author3 = new Author { Id = 3, AuthorName = "Author3" };



            List<Book> books = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Isbn = "123",
                    Title = "C# Unleashed",
                    Author = author1,
                    CategoryId = 1
                },
                new Book
                {
                    Id = 2,
                    Isbn = "213",
                    Title = "ASP.Net Unleashed",
                    Author = author2,
                    CategoryId = 2
                },
                new Book
                {
                    Id = 3,
                    Isbn = "312",
                    Title = "Java Unleashed",
                    Author = author3,
                    CategoryId = 1
                }
            };

            mapperMock.Setup(x =>
                    x.Map<List<BookViewModel>>(It.IsAny<List<Book>>()))
                .Returns(new List<BookViewModel>());

            repoMock.Setup(r => r.All()).Returns(books.AsQueryable());
            unitOfWorkMock.Setup(u => u.Books).Returns(repoMock.Object);

            var bookService = new BookService(unitOfWorkMock.Object, mapperMock.Object);

            var cut = bookService.GetBooksByTitle("Java Unleashed");

            Assert.AreEqual(1, cut.Count);

        }
    }
}
