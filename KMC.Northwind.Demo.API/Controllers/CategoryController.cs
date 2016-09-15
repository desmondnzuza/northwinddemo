﻿using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
using KMC.Northwind.Demo.Core.Model;
using System.Web.Http;

namespace KMC.Northwind.Demo.API.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryOperation _operation;

        public CategoryController(ICategoryOperation operation)
        {
            _operation = operation;
        }

        public Category[] FindCategories(SearchCriteria criteria)
        {
            return _operation.FindCategories(criteria);
        }

        public Category FindCategoryById(int categoryId)
        {
            return _operation.FindCategoryById(categoryId);
        }

        public void CreateCategory(Category newCategory)
        {
            _operation.CreateCategory(newCategory);
        }

        public void UpdateCategory(Category categoryToUpdate)
        {
            _operation.UpdateCategory(categoryToUpdate);
        }

        public void RemoveCategory(Category categoryToRemove)
        {
            _operation.RemoveCategory(categoryToRemove);
        }
    }
}