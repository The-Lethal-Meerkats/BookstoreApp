using BookstoreApp.Data.Repository.Contracts;
using BookstoreApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreApp.Tests.RepositoryTests
{
    [TestClass]
    public class BookRepositoryTests
    {
        // Should_ExpectedBehavior_When_StateUnderTest
        private readonly IRepository<Book> mockBookRepository;

        public BookRepositoryTests()
        {
            // Create some mock books to use

            var books = new List<Book>
                {
                    new Book { Id = 1, Isbn = "123",
                        Title = "C# Unleashed", AuthorId = 1, CategoryId = 1},
                    new Book { Id = 2, Isbn = "213",
                        Title = "ASP.Net Unleashed", AuthorId = 2, CategoryId = 1},
                    new Book { Id = 3, Isbn = "312",
                        Title = "Java Unleashed", AuthorId = 3, CategoryId = 1}
                }.AsQueryable();

            // Mock the Book Repository using Moq
            var mockBookRepository = new Mock<IRepository<Book>>();

            // Return all books
            mockBookRepository.Setup(x => x.All()).Returns(books);

            // Return a book by Id
            mockBookRepository.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns((int i) => books.Where(y => y.Id == i).Single());

            // Complete the setup of our Mock Product Repository
            this.mockBookRepository = mockBookRepository.Object;
        }

        [TestMethod]
        public void Should_NotReturnNull_When_GetAllIsCalled()
        {
            var testBooks = this.mockBookRepository.All();

            Assert.IsNotNull(testBooks);
        }

        [TestMethod]
        public void Should_ReturnCorrectCountOfBooks_When_GetAllIsCalled()
        {
            var testBooks = this.mockBookRepository.All();

            Assert.AreEqual(3, testBooks.Count());
        }

        [TestMethod]
        public void Should_ReturnCorrectCountOfBooksInList_When_GetAllIsCalled()
        {
            var testBooks = this.mockBookRepository.All();

            Assert.AreNotEqual(4, testBooks.Count());
        }

        [TestMethod]
        public void Should_NotReturnNullBook_When_GetByIdCalledWithAValidId()
        {
            var testBook = this.mockBookRepository.GetById(3);

            Assert.IsNotNull(testBook);
        }

        [TestMethod]
        public void Should_ThrowAnException_When_GetByIdCalledWithAnInvalidId()
        {
            Assert.ThrowsException<InvalidOperationException>(() => this.mockBookRepository.GetById(5));
        }

        [TestMethod]
        public void Should_ReturnAnInstanceOfBook_When_GetByIdCalledWithAValidId()
        {
            var testBook = this.mockBookRepository.GetById(2);

            Assert.IsInstanceOfType(testBook, typeof(Book));
        }

        [TestMethod]
        public void Should_ReturnRightBook_When_GetByIdCalledWithAValidId()
        {
            var testBook = this.mockBookRepository.GetById(2);

            Assert.AreEqual("ASP.Net Unleashed", testBook.Title);
        }
    }
}
