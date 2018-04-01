using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BookstoreApp.Data;
using BookstoreApp.Data.Repository;
using BookstoreApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookstoreApp.Tests.BookstoreApp.DataTests.RepositoryTests
{
    [TestClass]
    public class All_Should
    {
        [TestMethod]
        public void ReturnCorrectNumberOfCountries_WhenCalled()
        {
            var contextMock = new BookstoreContext(Effort.DbConnectionFactory.CreateTransient());

            var countryRepository = new GenericRepository<Country>(contextMock);
            
            var country = new Country(){CountryName = "Cambodia"};

            contextMock.Countries.Add(country);

            contextMock.SaveChanges();

            var result = countryRepository.All();

            Assert.AreEqual(1,result.Count());
        }
    }
}
