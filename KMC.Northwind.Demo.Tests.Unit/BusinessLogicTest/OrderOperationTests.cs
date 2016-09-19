using System;
using KMC.Northwind.Demo.BusinessLogic;
using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Should;

namespace KMC.Northwind.Demo.Tests.Unit.BusinessLogicTest
{
    [TestClass]
    public class OrderOperationTests
    {
        private Mock<IOrderRepository> _mockedOrderRepository;
        private IOrderOperation _sut;
        private Order[] _dummyOrders;

        [TestInitialize]
        public void SetUp()
        {
            _mockedOrderRepository = new Mock<IOrderRepository>();

            _dummyOrders = new Order[]
            {
                GenerateOrder(1, "ZA", "2000", "JHB"),
                GenerateOrder(2, "ZA", "2001", "CPT"),
                GenerateOrder(3, "ZA", "2001", "CPT"),
                GenerateOrder(3, "USA", "001", "NY"),
                GenerateOrder(3, "USA", "002", "CA"),
            };

            _mockedOrderRepository
                .Setup(r => r.FindOrdersBeingShiped())
                .Returns(_dummyOrders);

            _sut = new OrderOperation(_mockedOrderRepository.Object);
        }

        private Order GenerateOrder(
            int id, 
            string country, 
            string postalCode, 
            string city)
        {
            return new Order
            {
                Id = id,
                OrderDate = DateTime.Now.AddDays(-5),
                RequiredDate = DateTime.Now.AddDays(1),
                ShippedDate = DateTime.Now,
                ShipCountry = country,
                ShipPostalCode = postalCode,
                ShiptCity = city               
            };
        }

        [TestMethod]
        public void OrderOperationTests_WhenFindingOrderStats_Expect_OrderRepositoryCall_ToBeMade()
        {
            _sut.FindOrdersBeingShiped();

            _mockedOrderRepository.Verify(r => r.FindOrdersBeingShiped(), Times.Once());
        }

        [TestMethod]
        public void OrderOperationTests_WhenFindingOrderStatsAndXOrdersExists_Expect_XOrderStats_ToBeReturned()
        {
           var results = _sut.FindOrdersBeingShiped();

            results.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void OrderOperationTests_WhenOrderComeFromTwoCountries_Expect_Count_ToBeTwo()
        {
            var results = _sut.FindOrdersBeingShiped();

            results.Length.ShouldEqual(2);
        }
    }
}
