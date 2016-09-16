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
    public class SupplierRepositoryTests
    {
        private ISupplierRepository _sut;

        [TestInitialize]
        public void SetUp()
        {
            _sut = new SupplierRepository();
        }

        [TestMethod]
        public void SupplierRepositoryTests_WhenFindingAllSupplier_Expect_Results()
        {
            var results = _sut.FindAll();
            results.ShouldNotBeEmpty();
        }
    }
}
