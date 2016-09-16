using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;
using KMC.Northwind.Demo.SQL.Repository;
using KMC.Northwind.Demo.Tests.Common.Builders;
using KMC.Northwind.Demo.Tests.Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace KMC.Northwind.Demo.Tests.Integration.RepositoryTests
{
    [TestClass]
    public class ProductRepositoryTests
    {
        private IProductRepository _sut;

        [TestInitialize]
        public void SetUp()
        {
            _sut = new ProductRepository();
        }

        [TestMethod]
        public void ProductRepositoryTests_WhenFindingAllProducts_Expect_Results()
        {
            var results = _sut.FindAll();
            results.ShouldNotBeEmpty();
        }
    }
}
