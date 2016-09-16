using KMC.Northwind.Demo.Core.Interface.Repository;
using System;
using System.Linq;
using KMC.Northwind.Demo.Core.Model;
using SQLPOCO = KMC.Northwind.Demo.SQL.Repository.POCO;
using KMC.Northwind.Demo.SQL.Repository.Helpers;
using System.Data.Entity;

namespace KMC.Northwind.Demo.SQL.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void CreateProduct(Product newProduct)
        {
            throw new NotImplementedException();
        }

        public Product[] FindAll()
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                var dbResults = ctx.Products
                     .ToArray();

                var targetList = dbResults
                      .Select(x => x.ToCoreModelProduct())
                      .ToArray();

                return targetList;
            }
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
