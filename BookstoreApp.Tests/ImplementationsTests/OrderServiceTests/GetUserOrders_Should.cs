using System;
using AutoMapper;
using BookstoreApp.Services.AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookstoreApp.Tests.ImplementationsTests.OrderServiceTests
{
    [TestClass]
    public class GetUserOrders_Should
    {
        [ClassInitialize]
        public static void InitilizeAutomapper(TestContext context)
        {
            AutomapperConfig.Reset();
            AutomapperConfig.Initialize();
        }

        [TestMethod]
        public void ReturnAllOrders_WhenInvoked()
        {

        }

        [TestMethod]
        public void ThrowOutOfrangeException_WhenGivenInvalidParams()
        {

        }
    }
}
