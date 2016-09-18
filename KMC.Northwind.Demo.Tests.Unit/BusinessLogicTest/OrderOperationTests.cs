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
                new Order(),
                new Order(),
                new Order(),
            };

            _mockedOrderRepository
                .Setup(r => r.FindOrdersBeingShiped())
                .Returns(_dummyOrders);

            _sut = new OrderOperation(_mockedOrderRepository.Object);
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
    }
}
