using KMC.Northwind.Demo.BusinessLogic;
using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KMC.Northwind.Demo.Tests.Unit.BusinessLogicTest
{
    [TestClass]
    public class CategoryOperationTest
    {
        private Mock<ICategoryRepository> _mockedCategoryRepository;
        private Mock<IProductRepository> _mockedProductRepository;
        private ICategoryOperation _sut;

        [TestInitialize]
        public void SetUp()
        {
            _mockedCategoryRepository = new Mock<ICategoryRepository>();
            _mockedProductRepository = new Mock<IProductRepository>();

            _sut = new CategoryOperation(
                _mockedCategoryRepository.Object,
                _mockedProductRepository.Object);
        }

        [TestMethod]
        public void CategoryOperationTests_WhenFindingCategorys_Expect_CallRepositoryFindCall_ToBeMade()
        {
            var criteria = new SearchCriteria
            {
                From = 1,
                To = 10,
                SearchTerm = string.Empty
            };
            _sut.FindCategories(criteria);

            _mockedCategoryRepository.Verify(r => r.FindCategories(criteria), Times.Once);
        }

        [TestMethod]
        public void CategoryOperationTests_WhenFindingAvailableProducts_Expect_CallProductRepositoryFindAll_ToBeMade()
        {
            _sut.FindAvailableProducts();

            _mockedProductRepository.Verify(r => r.FindAll(), Times.Once);
        }

        [TestMethod]
        public void CategoryOperationTests_WhenFindingCategorysById_Expect_CallRepositoryFindByIdCall_ToBeMade()
        {
            var someNumber = 15478;
            _sut.FindCategoryById(someNumber);

            _mockedCategoryRepository.Verify(r => r.FindCategoryById(someNumber), Times.Once);
        }

        [TestMethod]
        public void CategoryOperationTests_WhenAddingNewCategory_Expect_RepositoryCallForAddNew_ToBeMade()
        {
            var dummyCategory = new Category();
            _sut.CreateCategory(dummyCategory);

            _mockedCategoryRepository.Verify(r => r.CreateCategory(dummyCategory), Times.Once);
        }

        [TestMethod]
        public void CategoryOperationTests_WhenUpdatingNewCategory_Expect_RepositoryCallForUpdate_ToBeMade()
        {
            var dummyCategory = new Category();
            _sut.UpdateCategory(dummyCategory);

            _mockedCategoryRepository.Verify(r => r.UpdateCategory(dummyCategory), Times.Once);
        }

        [TestMethod]
        public void CategoryOperationTests_WhenRemovingCategory_Expect_RepositoryCallForRemove_ToBeMade()
        {
            var dummyCategory = new Category();
            _sut.RemoveCategory(dummyCategory);

            _mockedCategoryRepository.Verify(r => r.RemoveCategory(dummyCategory), Times.Once);
        }
    }
}
