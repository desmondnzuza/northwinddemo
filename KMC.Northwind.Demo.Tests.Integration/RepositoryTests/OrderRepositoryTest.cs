﻿using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.SQL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace KMC.Northwind.Demo.Tests.Integration.RepositoryTests
{
    [TestClass]
    public class OrderRepositoryTest
    {
        private IOrderRepository _sut;

        [TestInitialize]
        public void SetUp()
        {
            _sut = new OrderRepository();
        }
        [TestMethod]
        public void OrderRepositoryTests_WhenFindingOrdersBeingShiped_Expect_Results()
        {
            var results = _sut.FindOrdersBeingShiped();

            results.ShouldNotBeEmpty();
        }
    }

}
