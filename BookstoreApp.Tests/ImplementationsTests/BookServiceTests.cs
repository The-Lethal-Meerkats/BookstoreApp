﻿using AutoMapper;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Data.Repository.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Services.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookstoreApp.ImplementationsTests
{
    [TestClass]
    public class BookServiceTests
    {
        // Should_ExpectedBehavior_When_StateUnderTest

        [TestMethod]
        public void Should_NotReturnNull_When_BookServiceCalled()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockMapper = new Mock<IMapper>();

            var bookService = new BookService(mockUnitOfWork.Object, mockMapper.Object);

            Assert.IsNotNull(bookService);
        }
    }
}
