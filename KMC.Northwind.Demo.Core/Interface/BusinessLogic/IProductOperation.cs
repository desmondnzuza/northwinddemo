using KMC.Northwind.Demo.Core.Model;

namespace KMC.Northwind.Demo.Core.Interface.BusinessLogic
{
    public interface IProductOperation
    {
        Product[] FindProducts(SearchCriteria criteria);
        Product FindProductById(int productId);
        void CreateProduct(Product newProduct);
        void UpdateProduct(Product productToUpdate);
        void RemoveProduct(Product productToRemove);
        Category[] FindAvailableCategories();
        Supplier[] FindAvailableSuppliers();
    }
}
