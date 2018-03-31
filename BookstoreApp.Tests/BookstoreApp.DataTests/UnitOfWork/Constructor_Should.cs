using System;
using BookstoreApp.Data;
using BookstoreApp.Data.Repository;
using BookstoreApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookstoreApp.Tests.BookstoreApp.DataTests.UnitOfWork
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullContext()
        {
            IBookstoreContext mockBookstoreContext = null;

            Assert.ThrowsException<ArgumentNullException>((() => new Data.UnitOfWork(mockBookstoreContext)));
        }

        [TestMethod]
        public void NotReturnNull_When_Invoked()
        {
            var mockBookstoreContext = new Mock<IBookstoreContext>();

            var UnitOfWork = new Data.UnitOfWork(mockBookstoreContext.Object);

            Assert.IsNotNull(UnitOfWork);
        }
    }
}
