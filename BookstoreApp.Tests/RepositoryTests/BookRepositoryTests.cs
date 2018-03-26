using BookstoreApp.Data;
using BookstoreApp.Data.Repository;
using BookstoreApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookstoreApp.Tests.RepositoryTests
{
    [TestClass]
    public class BookRepositoryTests
    {
        [TestMethod]
        public void Should_NotReturnNull_When_RepositoryCalled()
        {
            var mockBookstoreContext = new Mock<IBookstoreContext>();

            var bookRepository = new GenericRepository<Book>(mockBookstoreContext.Object);

            Assert.IsNotNull(bookRepository);
        }       
    }
}
