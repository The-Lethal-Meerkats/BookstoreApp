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
        
        [TestMethod]
        public void NotReturnNull_When_BookServiceCalled()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            var sut = new BookService(unitOfWorkMock.Object, mapperMock.Object);

            Assert.IsNotNull(sut);
        }
    }
}
