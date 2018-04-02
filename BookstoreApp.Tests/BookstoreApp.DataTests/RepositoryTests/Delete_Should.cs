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
    public class Delete_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_When_CalledWithAnInvalidId()
        {
            var contextMock = new Mock<IBookstoreContext>();

            var bookRepository = new GenericRepository<Book>(contextMock.Object);

            var invalidId = -1;

            Assert.ThrowsException<ArgumentException>(() => bookRepository.Delete(invalidId));
        }

        [TestMethod]
        public void ThrowArgumentNullException_When_CalledWithAnValidIdNumAndNoSuchItemExists()
        {
            var context = new BookstoreContext(Effort.DbConnectionFactory.CreateTransient());

            var bookRepository = new GenericRepository<Book>(context);

            var validIdWithNoItem = 2;

            Assert.ThrowsException<ArgumentNullException>(() => bookRepository.Delete(validIdWithNoItem));
        }

        [TestMethod]
        public void ThrowArgumentNullException_When_InvokedWithNullValue()
        {
            var contextMock = new Mock<IBookstoreContext>();

            var bookRepository = new GenericRepository<Book>(contextMock.Object);

            Book nullBook = null;

            Assert.ThrowsException<ArgumentNullException>(() => bookRepository.Delete(nullBook));
        }

        [TestMethod]
        public void Deletes_When_InvokedWithCorrectValues()
        {
            var context = new BookstoreContext(Effort.DbConnectionFactory.CreateTransient());

            var countryRepository = new GenericRepository<Author>(context);

            var author = new Author() { AuthorName = "gosho",Id =1 };
            var country1 = new Author() { AuthorName = "gosho1" };

            context.Authors.Add(author);
            context.SaveChanges();

            context.Authors.Add(country1);
            context.SaveChanges();

            countryRepository.Delete(1);
            context.SaveChanges();

            Assert.AreEqual(1,context.Authors.Count());
        }
        [TestMethod]
        public void DeletesEntity_When_InvokedWithCorrectValues()
        {
            var context = new BookstoreContext(Effort.DbConnectionFactory.CreateTransient());

            var countryRepository = new GenericRepository<Author>(context);

            var author = new Author() { AuthorName = "gosho", Id = 1 };
            var country1 = new Author() { AuthorName = "gosho1" };

            context.Authors.Add(author);
            context.SaveChanges();

            context.Authors.Add(country1);
            context.SaveChanges();

            countryRepository.Delete(author);
            context.SaveChanges();


            Assert.AreEqual(1, context.Authors.Count());
        }
    }
}
