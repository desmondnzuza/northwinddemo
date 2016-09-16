using KMC.Northwind.Demo.BusinessLogic;
using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KMC.Northwind.Demo.Tests.Unit.BusinessLogicTest
{
    [TestClass]
    public class ProductOperationTests
    {
        private Mock<IProductRepository> _mockedProductRepository;
        private Mock<ICategoryRepository> _mockedCategoryRepository;
        private Mock<ISupplierRepository> _mockedSupplierRepository;

        private IProductOperation _sut;

        [TestInitialize]
        public void SetUp()
        {
            _mockedProductRepository = new Mock<IProductRepository>();
            _mockedCategoryRepository = new Mock<ICategoryRepository>();
            _mockedSupplierRepository = new Mock<ISupplierRepository>();

            _sut = new ProductOperation(
                _mockedProductRepository.Object,
                _mockedCategoryRepository.Object,
                _mockedSupplierRepository.Object);
        }

        [TestMethod]
        public void ProductOperationTests_WhenFindingProducts_Expect_CallRepositoryFindCall_ToBeMade()
        {
            var criteria = new SearchCriteria
            {
                From = 1,
                To = 10,
                SearchTerm = string.Empty
            };
            _sut.FindProducts(criteria);

            _mockedProductRepository.Verify(r => r.FindProducts(criteria), Times.Once);
        }

        [TestMethod]
        public void ProductOperationTests_WhenFindingProductsById_Expect_CallRepositoryFindByIdCall_ToBeMade()
        {
            var someNumber = 15478;
            _sut.FindProductById(someNumber);

            _mockedProductRepository.Verify(r => r.FindProductById(someNumber), Times.Once);
        }

        [TestMethod]
        public void ProductOperationTests_WhenAddingNewProduct_Expect_RepositoryCallForAddNew_ToBeMade()
        {
            var dummyProduct = new Product();
            _sut.CreateProduct(dummyProduct);

            _mockedProductRepository.Verify(r => r.CreateProduct(dummyProduct), Times.Once);
        }

        [TestMethod]
        public void ProductOperationTests_WhenUpdatingNewProduct_Expect_RepositoryCallForUpdate_ToBeMade()
        {
            var dummyProduct = new Product();
            _sut.UpdateProduct(dummyProduct);

            _mockedProductRepository.Verify(r => r.UpdateProduct(dummyProduct), Times.Once);
        }

        [TestMethod]
        public void ProductOperationTests_WhenRemovingProduct_Expect_RepositoryCallForRemove_ToBeMade()
        {
            var dummyProduct = new Product();
            _sut.RemoveProduct(dummyProduct);

            _mockedProductRepository.Verify(r => r.RemoveProduct(dummyProduct), Times.Once);
        }

        [TestMethod]
        public void ProductOperationTests_WhenFindingAvailableCategories_Expect_CategoryRepositoryCallForFindAll_ToBeMade()
        {
            _sut.FindAvailableCategories();

            _mockedCategoryRepository.Verify(r => r.FindAll(), Times.Once);
        }

        [TestMethod]
        public void ProductOperationTests_WhenFindingAvailableSuppliers_Expect_SupplierRepositoryCallForFindAll_ToBeMade()
        {
            _sut.FindAvailableSuppliers();

            _mockedSupplierRepository.Verify(r => r.FindAll(), Times.Once);
        }
    }
}
