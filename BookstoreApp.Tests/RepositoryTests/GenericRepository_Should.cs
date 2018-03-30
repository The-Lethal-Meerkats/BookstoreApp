using BookstoreApp.Data.Repository.Contracts;
using BookstoreApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BookstoreApp.Data;
using BookstoreApp.Data.Repository;

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

        [TestMethod]
        public void ReturnAllBooks_When_GetAllIsCalled()
        {
            var context = new BookstoreContext(Effort.DbConnectionFactory.CreateTransient());

            var bookRepository = new GenericRepository<Book>(context);

            Book book1 = new Book()
            {
                Id = 1,
                Isbn = "123",
                Title = "C# Unleashed",
                AuthorId = 1,
                CategoryId = 1
            };

            bookRepository.Add(book1);

            var sut = bookRepository.All().ToList().Count;

            Assert.IsNotNull(sut);

        }
        //[TestMethod]
        //public void NotReturnNull_When_GetAllIsCalled()
        //{
        //    var mockBookstoreContext = new Mock<IBookstoreContext>();
        //    var DBsetMock = new Mock<IDbSet<Book>>();

        //    var bookRepository = new GenericRepository<Book>(mockBookstoreContext.Object);

        //    var books = new List<Book>
        //    {
        //        new Book { Id = 1, Isbn = "123",
        //            Title = "C# Unleashed", AuthorId = 1, CategoryId = 1},
        //        new Book { Id = 2, Isbn = "213",
        //            Title = "ASP.Net Unleashed", AuthorId = 2, CategoryId = 1},
        //        new Book { Id = 3, Isbn = "312",
        //            Title = "Java Unleashed", AuthorId = 3, CategoryId = 1}
        //    };
        //    DBsetMock.SetupGet()

        //    mockBookstoreContext.Setup(x => x.Books).Returns(books);


        //    Assert.IsNotNull(bookRepository.All());
        //}

        //[TestMethod]
        //public void Should_NotReturnNull_When_GetAllIsCalled()
        //{
        //    var mockBookRepository = new Mock<IRepository<Book>>();

        //    // Create some mock books to use
        //    var books = new List<Book>
        //        {
        //            new Book { Id = 1, Isbn = "123",
        //                Title = "C# Unleashed", AuthorId = 1, CategoryId = 1},
        //            new Book { Id = 2, Isbn = "213",
        //                Title = "ASP.Net Unleashed", AuthorId = 2, CategoryId = 1},
        //            new Book { Id = 3, Isbn = "312",
        //                Title = "Java Unleashed", AuthorId = 3, CategoryId = 1}
        //        }.AsQueryable();

        //    // Return all books
        //    mockBookRepository.Setup(x => x.All()).Returns(books);
        //    var testBooks = mockBookRepository.Object.All();

        //    Assert.IsNotNull(testBooks);
        //}

        //[TestMethod]
        //public void Should_ReturnCorrectCountOfBooks_When_GetAllIsCalled()
        //{
        //    var mockBookRepository = new Mock<IRepository<Book>>();

        //    var books = new List<Book>
        //        {
        //            new Book { Id = 1, Isbn = "123",
        //                Title = "C# Unleashed", AuthorId = 1, CategoryId = 1},
        //            new Book { Id = 2, Isbn = "213",
        //                Title = "ASP.Net Unleashed", AuthorId = 2, CategoryId = 1},
        //            new Book { Id = 3, Isbn = "312",
        //                Title = "Java Unleashed", AuthorId = 3, CategoryId = 1}
        //        }.AsQueryable();

        //    // Return all books
        //    mockBookRepository.Setup(x => x.All()).Returns(books);
        //    var testBooks = mockBookRepository.Object.All();

        //    Assert.AreEqual(3, testBooks.Count());
        //}

        //[TestMethod]
        //public void Should_ReturnCorrectCountOfBooksInList_When_GetAllIsCalled()
        //{
        //    var mockBookRepository = new Mock<IRepository<Book>>();

        //    var books = new List<Book>
        //        {
        //            new Book { Id = 1, Isbn = "123",
        //                Title = "C# Unleashed", AuthorId = 1, CategoryId = 1},
        //            new Book { Id = 2, Isbn = "213",
        //                Title = "ASP.Net Unleashed", AuthorId = 2, CategoryId = 1},
        //            new Book { Id = 3, Isbn = "312",
        //                Title = "Java Unleashed", AuthorId = 3, CategoryId = 1}
        //        }.AsQueryable();

        //    // Return all books
        //    mockBookRepository.Setup(x => x.All()).Returns(books);
        //    var testBooks = mockBookRepository.Object.All();

        //    Assert.AreNotEqual(4, testBooks.Count());
        //}

        //[TestMethod]
        //public void Should_NotReturnNullBook_When_GetByIdCalledWithAValidId()
        //{
        //    var mockBookRepository = new Mock<IRepository<Book>>();
        //    var books = new List<Book>
        //        {
        //            new Book { Id = 1, Isbn = "123",
        //                Title = "C# Unleashed", AuthorId = 1, CategoryId = 1},
        //            new Book { Id = 2, Isbn = "213",
        //                Title = "ASP.Net Unleashed", AuthorId = 2, CategoryId = 1},
        //            new Book { Id = 3, Isbn = "312",
        //                Title = "Java Unleashed", AuthorId = 3, CategoryId = 1}
        //        }.AsQueryable();

        //    mockBookRepository.Setup(x => x.GetById(It.IsAny<int>()))
        //        .Returns((int i) => books.Where(y => y.Id == i).Single());
        //    var testBook = mockBookRepository.Object.GetById(3);

        //    Assert.IsNotNull(testBook);
        //}

        [TestMethod]
        public void ThrowArgumentNullException_When_GetByIdCalledWithAnInvalidId()
        {
            var context = new BookstoreContext(Effort.DbConnectionFactory.CreateTransient());

            var bookRepository = new GenericRepository<Book>(context);

            var invalidId = -1;

            Assert.ThrowsException<ArgumentNullException>(() => bookRepository.GetById(invalidId));
        }



        [TestMethod]
        public void ReturnCorrectBook_When_GetByIdCalledWithAValidId()
        {
            var context = new BookstoreContext(Effort.DbConnectionFactory.CreateTransient());

            var bookRepository = new GenericRepository<Book>(context);

            Book book1 = new Book()
            {
                Id = 1,
                Isbn = "123",
                Title = "C# Unleashed",
                AuthorId = 1,
                CategoryId = 1
            };

            bookRepository.Add(book1);

            var sut = bookRepository.GetById(1);

            Assert.AreEqual(book1, sut);
        }

        [TestMethod]
        public void DeleteTheCorrectBook_When_CalledWithAValidId()
        {
            var context = new BookstoreContext(Effort.DbConnectionFactory.CreateTransient());

            var bookRepository = new GenericRepository<Book>(context);

            Book book1 = new Book()
            {
                Id = 1,
                Isbn = "123",
                Title = "C# Unleashed",
                AuthorId = 1,
                CategoryId = 1
            };

            bookRepository.Add(book1);

            int bookId = book1.Id;
            bookRepository.Delete(bookId);

            Assert.IsFalse(bookRepository.All().ToList().Contains(book1));
        }
        [TestMethod]
        public void DeleteTheCorrectBook_When_CalledWithAValidBook()
        {
            var context = new BookstoreContext(Effort.DbConnectionFactory.CreateTransient());

            var bookRepository = new GenericRepository<Book>(context);

            Book book1 = new Book()
            {
                Id = 1,
                Isbn = "123",
                Title = "C# Unleashed",
                AuthorId = 1,
                CategoryId = 1
            };

            bookRepository.Add(book1);

            
            bookRepository.Delete(book1);

            Assert.IsFalse(bookRepository.All().ToList().Contains(book1));
        }



        //[TestMethod]
        //public void Should_CallMethodOnlyOnce_When_DeleteWithIntegerAsParameterCalled()
        //{
        //    var mockBookRepository = new Mock<IRepository<Book>>();
        //    mockBookRepository.Setup(x => x.Delete(It.IsAny<Int32>())).Verifiable();
        //    mockBookRepository.Object.Delete(9);
        //    mockBookRepository.Verify(x => x.Delete(It.IsAny<Int32>()), Times.Once);
        //}

        //[TestMethod]
        //public void Should_UpdateBookTitle_When_UpdateMethodCalled()
        //{
        //    var mockBookRepository = new Mock<IRepository<Book>>();

        //    var books = new List<Book>
        //        {
        //            new Book { Id = 1, Isbn = "123",
        //                Title = "C# Unleashed", AuthorId = 1, CategoryId = 1},
        //            new Book { Id = 2, Isbn = "213",
        //                Title = "ASP.Net Unleashed", AuthorId = 2, CategoryId = 1},
        //            new Book { Id = 3, Isbn = "312",
        //                Title = "Java Unleashed", AuthorId = 3, CategoryId = 1}
        //        }.AsQueryable();

        //    mockBookRepository.Setup(x => x.GetById(It.IsAny<int>()))
        //        .Returns((int i) => books.Where(y => y.Id == i).Single());

        //    var testBook = mockBookRepository.Object.GetById(1);

        //    // Change one of its properties
        //    testBook.Title = "C# 3.5 Unleashed";

        //    mockBookRepository.Object.Update(testBook);

        //    // Verify the change
        //    Assert.AreEqual("C# 3.5 Unleashed", mockBookRepository.Object.GetById(1).Title);
        //}
    }
}
