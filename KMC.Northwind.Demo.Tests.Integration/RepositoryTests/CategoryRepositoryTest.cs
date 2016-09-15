using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;
using KMC.Northwind.Demo.SQL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace KMC.Northwind.Demo.Tests.Integration.BusinessLogicTest
{
    [TestClass]
    public class CategoryOperationTest
    {
        private ICategoryRepository _sut;

        [TestInitialize]
        public void SetUp()
        {
            _sut = new CategoryRepository();
        }

        [TestMethod]
        public void CategoryOperationTest_WhenFindingCategoriesWithValidRequest_Expect_Results()
        {
            var criteria = new SearchCriteria
            {
                From = 0,
                To = 10,
                SearchTerm = string.Empty
            };

            var results = _sut.FindCategories(criteria);

            results.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void CategoryOperationTest_WhenFindingCategoryByIdWithValidRequest_Expect_Results()
        {
            var results = _sut.FindCategoryById(1);

            results.ShouldNotBeNull();
        }
    }
}
