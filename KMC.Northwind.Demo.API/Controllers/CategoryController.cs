using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
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

        [HttpPost]
        public Category[] FindCategories([FromBody]SearchCriteria criteria)
        {
            return _operation.FindCategories(criteria);
        }

        [HttpGet]
        public Category FindCategoryById(int categoryId)
        {
            return _operation.FindCategoryById(categoryId);
        }

        [HttpPost]
        public void CreateCategory(Category newCategory)
        {
            _operation.CreateCategory(newCategory);
        }

        [HttpPost]
        public void UpdateCategory(Category categoryToUpdate)
        {
            _operation.UpdateCategory(categoryToUpdate);
        }

        [HttpPost]
        public void RemoveCategory(Category categoryToRemove)
        {
            _operation.RemoveCategory(categoryToRemove);
        }
    }
}