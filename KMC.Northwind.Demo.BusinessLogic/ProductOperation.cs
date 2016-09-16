using System;
using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;

namespace KMC.Northwind.Demo.BusinessLogic
{
    public class ProductOperation : IProductOperation
    {
        private readonly IProductRepository _repo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly ISupplierRepository _supplierRepo;

        public ProductOperation(
            IProductRepository repository,
            ICategoryRepository categoryRepository,
            ISupplierRepository supplierRepository)
        {
            _repo = repository;
            _categoryRepo = categoryRepository;
            _supplierRepo = supplierRepository;

        }

        public void CreateProduct(Product newProduct)
        {
            _repo.CreateProduct(newProduct);
        }

        public Product FindProductById(int productId)
        {
            return _repo.FindProductById(productId);
        }

        public Product[] FindProducts(SearchCriteria criteria)
        {
            return _repo.FindProducts(criteria);
        }

        public void RemoveProduct(Product productToRemove)
        {
            _repo.RemoveProduct(productToRemove);
        }

        public void UpdateProduct(Product productToUpdate)
        {
            _repo.UpdateProduct(productToUpdate);
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
