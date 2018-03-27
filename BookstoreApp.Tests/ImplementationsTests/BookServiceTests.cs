using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookstoreApp.Data;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Data.Repository.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Services.AutoMapper;
using BookstoreApp.Services.Implementation;
using BookstoreApp.Services.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookstoreApp.ImplementationsTests
{
    [TestClass]
    public class BookServiceTests
    {
        // Should_ExpectedBehavior_When_StateUnderTest
        [ClassInitialize]
        public static void InitilizeAutomapper(TestContext context)
        {
            AutomapperConfig.Initialize();
        }
        [TestMethod]
        public void Should_NotReturnNull_When_BookServiceCalled()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            var bookService = new BookService(unitOfWorkMock.Object, mapperMock.Object);

            Assert.IsNotNull(bookService);
        }

        [TestMethod]
        public void Should_Something()
        {
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repoMock = new Mock<IRepository<Book>>();

            var books = new List<Book>
            {
                new Book { Id = 1, Isbn = "123",
                    Title = "C# Unleashed", AuthorId = 1, CategoryId = 1},
                new Book { Id = 2, Isbn = "213",
                    Title = "ASP.Net Unleashed", AuthorId = 2, CategoryId = 1},
                new Book { Id = 3, Isbn = "312",
                    Title = "Java Unleashed", AuthorId = 3, CategoryId = 1}
            };

            mapperMock.Setup(x => 
                x.Map<List<Book>>(It.IsAny<List<BookViewModel>>()))
                .Returns(new List<Book>(books));

            repoMock.Setup(r => r.All()).Returns(books.AsQueryable());
            unitOfWorkMock.Setup(u => u.Books).Returns(repoMock.Object);


            var bookService = new BookService(unitOfWorkMock.Object, mapperMock.Object);

            var res = bookService.GetAllBooks();

            Assert.AreEqual(3, res.Count);
        }
    }
}
