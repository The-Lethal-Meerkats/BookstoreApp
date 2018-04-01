using BookstoreApp.Data;
using BookstoreApp.Data.Repository;
using BookstoreApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BookstoreApp.Tests.RepositoryTests
{
    [TestClass]
    public class GenericRepository_Should
    {
        [TestMethod]
        public void NotReturnNull_When_RepositoryCalled()
        {
            var mockBookstoreContext = new Mock<IBookstoreContext>();

            var bookRepository = new GenericRepository<Book>(mockBookstoreContext.Object);

            Assert.IsNotNull(bookRepository);
        }

        [TestMethod]
        public void ThrowNullException_When_RepositoryInvokedWithNullContext()
        {
            IBookstoreContext mockBookstoreContext = null;

            Assert.ThrowsException<ArgumentNullException>((() => new GenericRepository<Book>(mockBookstoreContext)));
        }

    }
}
