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
    public class GenericRepositoryTests
    {
        [TestMethod]
        public void TShould_NotReturnNull_When_GetAllIsCalled()
        {
            var mockBookRepository = new Mock<IRepository<Book>>();

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

            // Return all books
            mockBookRepository.Setup(x => x.All()).Returns(books);
            var testBooks = mockBookRepository.Object.All();

            Assert.IsNotNull(testBooks);
        }

        [TestMethod]
        public void Should_NotReturnNull_When_GetAllIsCalled()
        {
            var mockBookRepository = new Mock<IRepository<Book>>();

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

            // Return all books
            mockBookRepository.Setup(x => x.All()).Returns(books);
            var testBooks = mockBookRepository.Object.All();

            Assert.IsNotNull(testBooks);
        }

        [TestMethod]
        public void Should_ReturnCorrectCountOfBooks_When_GetAllIsCalled()
        {
            var mockBookRepository = new Mock<IRepository<Book>>();

            var books = new List<Book>
                {
                    new Book { Id = 1, Isbn = "123",
                        Title = "C# Unleashed", AuthorId = 1, CategoryId = 1},
                    new Book { Id = 2, Isbn = "213",
                        Title = "ASP.Net Unleashed", AuthorId = 2, CategoryId = 1},
                    new Book { Id = 3, Isbn = "312",
                        Title = "Java Unleashed", AuthorId = 3, CategoryId = 1}
                }.AsQueryable();

            // Return all books
            mockBookRepository.Setup(x => x.All()).Returns(books);
            var testBooks = mockBookRepository.Object.All();

            Assert.AreEqual(3, testBooks.Count());
        }

        [TestMethod]
        public void Should_ReturnCorrectCountOfBooksInList_When_GetAllIsCalled()
        {
            var mockBookRepository = new Mock<IRepository<Book>>();

            var books = new List<Book>
                {
                    new Book { Id = 1, Isbn = "123",
                        Title = "C# Unleashed", AuthorId = 1, CategoryId = 1},
                    new Book { Id = 2, Isbn = "213",
                        Title = "ASP.Net Unleashed", AuthorId = 2, CategoryId = 1},
                    new Book { Id = 3, Isbn = "312",
                        Title = "Java Unleashed", AuthorId = 3, CategoryId = 1}
                }.AsQueryable();

            // Return all books
            mockBookRepository.Setup(x => x.All()).Returns(books);
            var testBooks = mockBookRepository.Object.All();

            Assert.AreNotEqual(4, testBooks.Count());
        }

        [TestMethod]
        public void Should_NotReturnNullBook_When_GetByIdCalledWithAValidId()
        {
            var mockBookRepository = new Mock<IRepository<Book>>();
            var books = new List<Book>
                {
                    new Book { Id = 1, Isbn = "123",
                        Title = "C# Unleashed", AuthorId = 1, CategoryId = 1},
                    new Book { Id = 2, Isbn = "213",
                        Title = "ASP.Net Unleashed", AuthorId = 2, CategoryId = 1},
                    new Book { Id = 3, Isbn = "312",
                        Title = "Java Unleashed", AuthorId = 3, CategoryId = 1}
                }.AsQueryable();

            mockBookRepository.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns((int i) => books.Where(y => y.Id == i).Single());
            var testBook = mockBookRepository.Object.GetById(3);

            Assert.IsNotNull(testBook);
        }

        [TestMethod]
        public void Should_ThrowAnException_When_GetByIdCalledWithAnInvalidId()
        {
            var mockBookRepository = new Mock<IRepository<Book>>();

            var books = new List<Book>
                {
                    new Book { Id = 1, Isbn = "123",
                        Title = "C# Unleashed", AuthorId = 1, CategoryId = 1},
                    new Book { Id = 2, Isbn = "213",
                        Title = "ASP.Net Unleashed", AuthorId = 2, CategoryId = 1},
                    new Book { Id = 3, Isbn = "312",
                        Title = "Java Unleashed", AuthorId = 3, CategoryId = 1}
                }.AsQueryable();

            mockBookRepository.Setup(x => x.GetById(It.IsAny<int>()))
               .Returns((int i) => books.Where(y => y.Id == i).Single());

            Assert.ThrowsException<InvalidOperationException>(() => mockBookRepository.Object.GetById(5));
        }

        [TestMethod]
        public void Should_ReturnAnInstanceOfBook_When_GetByIdCalledWithAValidId()
        {
            var mockBookRepository = new Mock<IRepository<Book>>();

            var books = new List<Book>
                {
                    new Book { Id = 1, Isbn = "123",
                        Title = "C# Unleashed", AuthorId = 1, CategoryId = 1},
                    new Book { Id = 2, Isbn = "213",
                        Title = "ASP.Net Unleashed", AuthorId = 2, CategoryId = 1},
                    new Book { Id = 3, Isbn = "312",
                        Title = "Java Unleashed", AuthorId = 3, CategoryId = 1}
                }.AsQueryable();

            mockBookRepository.Setup(x => x.GetById(It.IsAny<int>()))
               .Returns((int i) => books.Where(y => y.Id == i).Single());

            var testBook = mockBookRepository.Object.GetById(2);

            Assert.IsInstanceOfType(testBook, typeof(Book));
        }

        [TestMethod]
        public void Should_ReturnRightBook_When_GetByIdCalledWithAValidId()
        {
            var mockBookRepository = new Mock<IRepository<Book>>();

            var books = new List<Book>
                {
                    new Book { Id = 1, Isbn = "123",
                        Title = "C# Unleashed", AuthorId = 1, CategoryId = 1},
                    new Book { Id = 2, Isbn = "213",
                        Title = "ASP.Net Unleashed", AuthorId = 2, CategoryId = 1},
                    new Book { Id = 3, Isbn = "312",
                        Title = "Java Unleashed", AuthorId = 3, CategoryId = 1}
                }.AsQueryable();

            mockBookRepository.Setup(x => x.GetById(It.IsAny<int>()))
               .Returns((int i) => books.Where(y => y.Id == i).Single());

            var testBook = mockBookRepository.Object.GetById(2);

            Assert.AreEqual("ASP.Net Unleashed", testBook.Title);
        }

        [TestMethod]
        public void Should_CallMethodOnlyOnce_When_AddCalled()
        {
            var newBook = new Book
            {
                Id = 4,
                Isbn = "2213",
                Title = "Pro C#",
                AuthorId = 4,
                CategoryId = 2
            };
            var mockBookRepository = new Mock<IRepository<Book>>();
            mockBookRepository.Setup(x => x.Add(It.IsAny<Book>())).Verifiable();
            mockBookRepository.Object.Add(newBook);
            mockBookRepository.Verify(x => x.Add(It.IsAny<Book>()), Times.Once);
        }

        [TestMethod]
        public void Should_CallMethodOnlyOnce_When_DeleteCalled()
        {
            var newBook = new Book
            {
                Id = 4,
                Isbn = "2213",
                Title = "Pro C#",
                AuthorId = 4,
                CategoryId = 2
            };
            var mockBookRepository = new Mock<IRepository<Book>>();
            mockBookRepository.Setup(x => x.Delete(It.IsAny<Book>())).Verifiable();
            mockBookRepository.Object.Delete(newBook);
            mockBookRepository.Verify(x => x.Delete(It.IsAny<Book>()), Times.Once);
        }

        [TestMethod]
        public void Should_CallMethodOnlyOnce_When_DeleteWithIntegerAsParameterCalled()
        {
            var mockBookRepository = new Mock<IRepository<Book>>();
            mockBookRepository.Setup(x => x.Delete(It.IsAny<Int32>())).Verifiable();
            mockBookRepository.Object.Delete(9);
            mockBookRepository.Verify(x => x.Delete(It.IsAny<Int32>()), Times.Once);
        }

        [TestMethod]
        public void Should_UpdateBookTitle_When_UpdateMethodCalled()
        {
            var mockBookRepository = new Mock<IRepository<Book>>();

            var books = new List<Book>
                {
                    new Book { Id = 1, Isbn = "123",
                        Title = "C# Unleashed", AuthorId = 1, CategoryId = 1},
                    new Book { Id = 2, Isbn = "213",
                        Title = "ASP.Net Unleashed", AuthorId = 2, CategoryId = 1},
                    new Book { Id = 3, Isbn = "312",
                        Title = "Java Unleashed", AuthorId = 3, CategoryId = 1}
                }.AsQueryable();

            mockBookRepository.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns((int i) => books.Where(y => y.Id == i).Single());

            var testBook = mockBookRepository.Object.GetById(1);

            // Change one of its properties
            testBook.Title = "C# 3.5 Unleashed";

            mockBookRepository.Object.Update(testBook);

            // Verify the change
            Assert.AreEqual("C# 3.5 Unleashed", mockBookRepository.Object.GetById(1).Title);
        }
    }
}
