using AutoMapper;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Services.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookstoreApp.Tests.ImplementationsTests.BookServiceTests
{
    [TestClass]
    public class Constructor_Should
    {        
        [TestMethod]
        public void NotReturnNull_When_BookServiceCalled()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            var bookService = new BookService(unitOfWorkMock.Object, mapperMock.Object);

            Assert.IsNotNull(bookService);
        }
    }
}
