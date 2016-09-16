using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;

namespace KMC.Northwind.Demo.BusinessLogic
{
    public class CategoryOperation : ICategoryOperation
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IProductRepository _productRepo;

        public CategoryOperation(
            ICategoryRepository categoryRepository,
            IProductRepository productRepository)
        {
            _categoryRepo = categoryRepository;
            _productRepo = productRepository;
        }

        public void CreateCategory(Category newCategory)
        {
            _categoryRepo.CreateCategory(newCategory);
        }

        public Product[] FindAvailableProducts()
        {
            return _productRepo.FindAll();
        }

        public Category[] FindCategories(SearchCriteria criteria)
        {
            return _categoryRepo.FindCategories(criteria);
        }

        public Category FindCategoryById(int categoryId)
        {
            return _categoryRepo.FindCategoryById(categoryId);
        }

        public void RemoveCategory(Category categoryToRemove)
        {
            _categoryRepo.RemoveCategory(categoryToRemove);
        }

        public void UpdateCategory(Category categoryToUpdate)
        {
            _categoryRepo.UpdateCategory(categoryToUpdate);
        }
    }
}
