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
        private string _randomName;
        private int _supplierId;

        [TestInitialize]
        public void SetUp()
        {
            _sut = new SupplierRepository();
            _randomName = string.Format("TEST_{0}", StringHelper.GenerateRandomNumber());

            _supplierId = new SupplierIdBuilder()
                .WithCompanyName(_randomName)
                .WithContactName("John Doe")
                .Build();
        }

        [TestCleanup]
        public void CleanUp()
        {
            SupplierHelper.DeleteSupplierById(_supplierId);
        }

        [TestMethod]
        public void SupplierRepositoryTests_WhenFindingAllSupplier_Expect_Results()
        {
            var results = _sut.FindAll();
            results.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void SupplierRepositoryTests_WhenFindingSupplierWithValidRequest_Expect_Results()
        {
            var criteria = new SearchCriteria
            {
                From = 0,
                To = 10,
                SearchTerm = _randomName
            };

            var results = _sut.FindSuppliers(criteria);

            results.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void SupplierRepositoryTests_WhenFindingSupplierByIdWithValidRequest_Expect_Results()
        {
            var results = _sut.FindSupplierById(_supplierId);

            results.ShouldNotBeNull();
        }

        [TestMethod]
        public void SupplierOperationTest_WhenAddingSupplierWithValidRequest_Expect_NewSupplierToBeAdded()
        {
            var name = string.Format("ADD_{0}", StringHelper.GenerateRandomNumber());
            var SupplierToAdd = new Supplier
            {
                CompanyName = name,
                ContactName = "Test for add",
            };

            _sut.CreateSupplier(SupplierToAdd);

            var dbResult = SupplierHelper.FindSupplierByCompanyName(name);
            dbResult.ShouldNotBeNull();

            SupplierHelper.DeleteSupplierById(dbResult.SupplierId);
            dbResult.CompanyName.ShouldEqual(name);
        }

        [TestMethod]
        public void SupplierOperationTest_WhenUpdatingSupplierWithValidRequest_Expect_SupplierToBeUpdated()
        {
            var name = string.Format("UP_{0}", StringHelper.GenerateRandomNumber());

            var SupplierToUpdate = new Supplier
            {
                Id = _supplierId,
                CompanyName = name,
                ContactName = "Test Update",
            };

            _sut.UpdateSupplier(SupplierToUpdate);

            var dbResult = SupplierHelper.FindSupplierByCompanyName(name);
            dbResult.ShouldNotBeNull();

            dbResult.CompanyName.ShouldEqual(name);
        }

        [TestMethod]
        public void SupplierOperationTest_WhenDeletingSupplierWithValidRequest_Expect_SupplierToBeRemoved()
        {
            var name = string.Format("DEL_{0}", StringHelper.GenerateRandomNumber());
            var existingProducts = ProductHelper.FindTopProducts(5);

            var SupplierToRemove = new Supplier
            {
                Id = _supplierId,
                CompanyName = name,
                ContactName = "Test Delete",
                Products = existingProducts
            };

            _sut.RemoveSupplier(SupplierToRemove);

            var dbResult = SupplierHelper.FindSupplierById(_supplierId);
            dbResult.ShouldBeNull();
        }
    }
}
