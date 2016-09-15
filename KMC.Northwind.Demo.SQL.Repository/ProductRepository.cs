using KMC.Northwind.Demo.Core.Interface.Repository;
using System;
using System.Linq;
using KMC.Northwind.Demo.Core.Model;
using SQLPOCO = KMC.Northwind.Demo.SQL.Repository.POCO;
using System.Data.Entity;

namespace KMC.Northwind.Demo.SQL.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void CreateProduct(Product newProduct)
        {
            throw new NotImplementedException();
        }

        public Product FindProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public Product[] FindProducts(SearchCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(Product productToRemove)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product productToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
