﻿using System;
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

            var countryRepository = new GenericRepository<Country>(context);

            var country = new Country() { CountryName = "gosho", Id = 1 };
            var country1 = new Country() { CountryName = "gosho1" };

            countryRepository.Add(country);
            context.SaveChanges();
            countryRepository.Add(country1);
            context.SaveChanges();

            var expectedResult = 2;

            Assert.AreEqual(expectedResult, context.Countries.Count());
        }
    }
}
