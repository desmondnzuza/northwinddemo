using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;

namespace KMC.Northwind.Demo.BusinessLogic
{
    public class ProductOperation : IProductOperation
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly ISupplierRepository _supplierRepo;

        public ProductOperation(
            IProductRepository repository,
            ICategoryRepository categoryRepository,
            ISupplierRepository supplierRepository)
        {
            _productRepo = repository;
            _categoryRepo = categoryRepository;
            _supplierRepo = supplierRepository;
        }

        public void CreateProduct(Product newProduct)
        {
            _productRepo.CreateProduct(newProduct);
        }

        public Product FindProductById(int productId)
        {
            return _productRepo.FindProductById(productId);
        }

        public Product[] FindProducts(SearchCriteria criteria)
        {
            return _productRepo.FindProducts(criteria);
        }

        public void RemoveProduct(Product productToRemove)
        {
            _productRepo.RemoveProduct(productToRemove);
        }

        public void UpdateProduct(Product productToUpdate)
        {
            _productRepo.UpdateProduct(productToUpdate);
        }

        public Category[] FindAvailableCategories()
        {
            return _categoryRepo.FindAll();
        }

        public Supplier[] FindAvailableSuppliers()
        {
            return _supplierRepo.FindAll();
        }
    }
}
