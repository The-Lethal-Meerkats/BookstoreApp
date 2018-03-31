using System;
using BookstoreApp.Data;
using BookstoreApp.Data.Repository;
using BookstoreApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookstoreApp.Tests.RepositoryTests
{
    [TestClass]
    public class GetById_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_When_GetByIdCalledWithAnInvalidId()
        {
            var contextMock = new Mock<IBookstoreContext>();

            var bookRepository = new GenericRepository<Book>(contextMock.Object);

            var invalidId = -1;

            Assert.ThrowsException<ArgumentException>(() => bookRepository.GetById(invalidId));
        }

        [TestMethod]
        public void ThrowArgumentNullException_When_GetByIdCalledWithAnValidIdNumAndNoSuchItemExists()
        {
            var context = new BookstoreContext(Effort.DbConnectionFactory.CreateTransient());

            var bookRepository = new GenericRepository<Book>(context);

            var validIdWithNoItem = 2;

            Assert.ThrowsException<ArgumentNullException>(() => bookRepository.GetById(validIdWithNoItem));
        }
    }
}
