using KMC.Northwind.Demo.Core.Model;

namespace KMC.Northwind.Demo.Core.Interface.BusinessLogic
{
    public interface ICategoryOperation
    {
        Category[] FindCategories(SearchCriteria criteria);
        Category FindCategoryById(int categoryId);
        void CreateCategory(Category newCategory);
        void UpdateCategory(Category categoryToUpdate);
        void RemoveCategory(Category categoryToRemove);
    }
}
