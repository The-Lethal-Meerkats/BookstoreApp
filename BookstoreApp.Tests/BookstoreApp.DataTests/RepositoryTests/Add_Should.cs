using System;
using System.Linq;
using BookstoreApp.Data;
using BookstoreApp.Data.Repository;
using BookstoreApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookstoreApp.Tests.RepositoryTests
{
    [TestClass]
    public class Add_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_When_InvokedWithNullValue()
        {
            var contextMock = new Mock<IBookstoreContext>();

            var bookRepository = new GenericRepository<Book>(contextMock.Object);

            Book nullBook = null;

            Assert.ThrowsException<ArgumentNullException>(() => bookRepository.Add(nullBook));
        }

        [TestMethod]
        public void AddsSuccesfully_When_InvokedWithCorrectValues()
        {
            var context = new BookstoreContext(Effort.DbConnectionFactory.CreateTransient());

            var countryRepository = new GenericRepository<Author>(context);

            var author = new Author() { AuthorName = "gosho" };
            var author1 = new Author() { AuthorName = "gosho1" };

            countryRepository.Add(author);
            context.SaveChanges();
            countryRepository.Add(author1);
            context.SaveChanges();

            var expectedResult = 2;

            Assert.AreEqual(expectedResult, context.Authors.Count());
        }
    }
}
