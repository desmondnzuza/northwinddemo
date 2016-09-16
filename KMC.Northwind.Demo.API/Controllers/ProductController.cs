using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
using KMC.Northwind.Demo.Core.Model;
using System.Web.Http;

namespace KMC.Northwind.Demo.API.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductOperation _operation;

        public ProductController(IProductOperation operation)
        {
            _operation = operation;
        }

        [HttpPost]
        public Product[] FindProducts([FromBody]SearchCriteria criteria)
        {
            return _operation.FindProducts(criteria);
        }

        [HttpGet]
        public Category[] FindAvailableCategories()
        {
            return _operation.FindAvailableCategories();
        }

        [HttpGet]
        public Supplier[] FindAvailableSuppliers()
        {
            return _operation.FindAvailableSuppliers();
        }

        [HttpGet]
        public Product FindProductById(int productId)
        {
            return _operation.FindProductById(productId);
        }

        [HttpPost]
        public void CreateProduct(Product newProduct)
        {
            _operation.CreateProduct(newProduct);
        }

        [HttpPost]
        public void UpdateProduct(Product productToUpdate)
        {
            _operation.UpdateProduct(productToUpdate);
        }

        [HttpPost]
        public void RemoveProduct(Product productToRemove)
        {
            _operation.RemoveProduct(productToRemove);
        }
    }
}