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
        private string _randomName;
        private int _productId;

        [TestInitialize]
        public void SetUp()
        {
            _sut = new ProductRepository();

            _randomName = string.Format("TEST_{0}", StringHelper.GenerateRandomNumber());
            _productId = new ProductIdBuilder()
                .WithName(_randomName)
                .Build();
        }

        [TestCleanup]
        public void CleanUp()
        {
            ProductHelper.DeleteProductById(_productId);
        }

        [TestMethod]
        public void ProductRepositoryTests_WhenFindingProductsWithValidRequest_Expect_Results()
        {
            var criteria = new SearchCriteria
            {
                From = 0,
                To = 10,
                SearchTerm = _randomName
            };

            var results = _sut.FindProducts(criteria);

            results.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void ProductRepositoryTests_WhenFindingProductByIdWithValidRequest_Expect_Results()
        {
            var results = _sut.FindProductById(_productId);

            results.ShouldNotBeNull();
        }

        [TestMethod]
        public void ProductRepositoryTests_WhenFindingAllProducts_Expect_Results()
        {
            var results = _sut.FindAll();
            results.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void ProductOperationTest_WhenAddingProductWithValidRequest_Expect_NewProductToBeAdded()
        {
            var name = string.Format("ADD_{0}", StringHelper.GenerateRandomNumber());
            var ProductToAdd = new Product
            {
                Name = name,
                QuantityPerUnit = "Test for add",
            };

            _sut.CreateProduct(ProductToAdd);

            var dbResult = ProductHelper.FindRecordByName(name);
            dbResult.ShouldNotBeNull();

            ProductHelper.DeleteProductById(dbResult.ProductId);
            dbResult.ProductName.ShouldEqual(name);
        }

        [TestMethod]
        public void ProductOperationTest_WhenUpdatingProductWithValidRequest_Expect_ProductToBeUpdated()
        {
            var name = string.Format("UP_{0}", StringHelper.GenerateRandomNumber());

            var ProductToUpdate = new Product
            {
                Id = _productId,
                Name = name,
                QuantityPerUnit = "Test Update",
            };

            _sut.UpdateProduct(ProductToUpdate);

            var dbResult = ProductHelper.FindRecordByName(name);
            dbResult.ShouldNotBeNull();

            dbResult.ProductName.ShouldEqual(name);
        }

        [TestMethod]
        public void ProductOperationTest_WhenDeletingProductWithValidRequest_Expect_ProductToBeRemoved()
        {
            var existingProducts = ProductHelper.FindTopProducts(2);

            var ProductToRemove = new Product
            {
                Id = _productId,
                QuantityPerUnit = "Test Update DELETE"
            };

            _sut.RemoveProduct(ProductToRemove);

            var dbResult = ProductHelper.FindProductById(_productId);
            dbResult.ShouldBeNull();
        }
    }
}
