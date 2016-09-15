using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;

namespace KMC.Northwind.Demo.BusinessLogic
{
    public class ProductOperation : IProductOperation
    {
        private readonly IProductRepository _repo;

        public ProductOperation(IProductRepository repository)
        {
            _repo = repository;
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
    }
}
