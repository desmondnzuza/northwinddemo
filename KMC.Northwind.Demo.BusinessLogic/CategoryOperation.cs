using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;

namespace KMC.Northwind.Demo.BusinessLogic
{
    public class CategoryOperation : ICategoryOperation
    {
        private readonly ICategoryRepository _repo;

        public CategoryOperation(ICategoryRepository repository)
        {
            _repo = repository;
        }

        public void CreateCategory(Category newCategory)
        {
            _repo.CreateCategory(newCategory);
        }

        public Category[] FindCategories(SearchCriteria criteria)
        {
            return _repo.FindCategories(criteria);
        }

        public Category FindCategoryById(int categoryId)
        {
            return _repo.FindCategoryById(categoryId);
        }

        public void RemoveCategory(Category categoryToRemove)
        {
            _repo.RemoveCategory(categoryToRemove);
        }

        public void UpdateCategory(Category categoryToUpdate)
        {
            _repo.UpdateCategory(categoryToUpdate);
        }
    }
}
