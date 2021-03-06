﻿using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;
using KMC.Northwind.Demo.SQL.Repository;
using KMC.Northwind.Demo.Tests.Common.Builders;
using KMC.Northwind.Demo.Tests.Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace KMC.Northwind.Demo.Tests.Integration.BusinessLogicTest
{
    [TestClass]
    public class CategoryReposirotyTest
    {
        private ICategoryRepository _sut;
        private string _randomName;
        private int _categoryId;

        [TestInitialize]
        public void SetUp()
        {
            _sut = new CategoryRepository();

            _randomName = string.Format("TEST_{0}", StringHelper.GenerateRandomNumber());

            _categoryId = new CategoryIdBuilder()
                .WithName(_randomName)
                .Build();
        }

        [TestCleanup]
        public void CleanUp()
        {
            CategoryHelper.DeleteCategoryById(_categoryId);
        }

        [TestMethod]
        public void CategoryReposirotyTest_WhenFindingCategoriesWithValidRequest_Expect_Results()
        {
            var criteria = new SearchCriteria
            {
                From = 0,
                To = 10,
                SearchTerm = _randomName
            };

            var results = _sut.FindCategories(criteria);

            results.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void CategoryReposirotyTest_WhenFindingCategoryByIdWithValidRequest_Expect_Results()
        {
            var results = _sut.FindCategoryById(_categoryId);

            results.ShouldNotBeNull();
        }

        [TestMethod]
        public void CategoryRepositoryTests_WhenFindingAllCategories_Expect_Results()
        {
            var results = _sut.FindAll();
            results.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void CategoryReposirotyTest_WhenAddingCategoryWithValidRequest_Expect_NewCategoryToBeAdded()
        {
            var name = string.Format("ADD_{0}", StringHelper.GenerateRandomNumber());
            var categoryToAdd = new Category
            {
                Name = name,
                Description = "Testing to see if can add record",
            };

            _sut.CreateCategory(categoryToAdd);

            var dbResult = CategoryHelper.FindRecordByName(name);
            dbResult.ShouldNotBeNull();

            CategoryHelper.DeleteCategoryById(dbResult.CategoryId);            
            dbResult.CategoryName.ShouldEqual(name);
        }

        [TestMethod]
        public void CategoryReposirotyTest_WhenUpdatingCategoryWithValidRequest_Expect_CategoryToBeUpdated()
        {
            var name = string.Format("UP_{0}", StringHelper.GenerateRandomNumber());
            var categoryToUpdate = new Category
            {
                Id = _categoryId,
                Name = name,
                Description = "Testing to see if can Update record",
            };

            _sut.UpdateCategory(categoryToUpdate);

            var dbResult = CategoryHelper.FindRecordByName(name);
            dbResult.ShouldNotBeNull();
            
            dbResult.CategoryName.ShouldEqual(name);
        }

        [TestMethod]
        public void CategoryReposirotyTest_WhenDeletingCategoryWithValidRequest_Expect_CategoryToBeRemoved()
        {
            var existingProducts = ProductHelper.FindTopProducts(2);

            var categoryToRemove = new Category
            {
                Id = _categoryId,
                Description = "Testing to see if can delete record",
                Products = existingProducts
            };

            _sut.RemoveCategory(categoryToRemove);

            var dbResult = CategoryHelper.FindRecordId(_categoryId);
            dbResult.ShouldBeNull();
        }

        [TestMethod]
        public void CategoryReposirotyTest_WhenUpdatingCategoryAfterModifyingProducts_Expect_CategoryToHaveNewProducts()
        {
            var name = string.Format("UP_{0}", StringHelper.GenerateRandomNumber());

            var existingProducts = ProductHelper.FindTopProducts(2);

            var categoryToUpdate = new Category
            {
                Id = _categoryId,
                Name = name,
                Description = "Testing to see if can Update record",
                Products = existingProducts
            };

            _sut.UpdateCategory(categoryToUpdate);

            var dbResult = CategoryHelper.FindRecordByName(name);
            dbResult.ShouldNotBeNull();

            dbResult.Products.ShouldNotBeEmpty();
        }
    }
}
