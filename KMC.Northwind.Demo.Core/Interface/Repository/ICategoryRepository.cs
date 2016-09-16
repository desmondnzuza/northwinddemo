

namespace KMC.Northwind.Demo.Core.Interface.Repository
{
    using KMC.Northwind.Demo.Core.Model;

    public interface ICategoryRepository
    {
        Category[] FindCategories(SearchCriteria criteria);
        Category[] FindAll();
        Category FindCategoryById(int categoryId);
        void CreateCategory(Category newCategory);
        void UpdateCategory(Category categoryToUpdate);
        void RemoveCategory(Category categoryToRemove);
    }
}
