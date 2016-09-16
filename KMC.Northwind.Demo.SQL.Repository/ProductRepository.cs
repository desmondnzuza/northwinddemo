using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;
using KMC.Northwind.Demo.SQL.Repository.Helpers;
using System.Linq;
using SQLPOCO = KMC.Northwind.Demo.SQL.Repository.POCO;

namespace KMC.Northwind.Demo.SQL.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void CreateProduct(Product newProduct)
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                var itemToAdd = newProduct.ToDbProduct();
                ctx.Products.Add(itemToAdd);

                ctx.SaveChanges();
            }
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
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                var dbProduct = ctx.Products
                    .FirstOrDefault(p => p.ProductId == productId);

                if (dbProduct != null)
                {
                    return dbProduct.ToCoreModelProduct();
                }
            }

            return null;
        }

        public Product[] FindProducts(SearchCriteria criteria)
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                var dbResults = ctx.Products
                    .Where(p => 
                          ( p.ProductName.Contains(criteria.SearchTerm) ||
                            p.QuantityPerUnit.Contains(criteria.SearchTerm) || 
                            criteria.SearchTerm == null))                       //TODO: handle this better
                     .ToArray();

                var targetList = dbResults
                      .Select(x => x.ToCoreModelProduct())
                      .ToArray();

                return targetList;
            }
        }

        public void RemoveProduct(Product productToRemove)
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                var categoryToDelete = ctx.Products
                    .FirstOrDefault(c => c.ProductId == productToRemove.Id);

                if (categoryToDelete != null)
                {
                    ctx.Products.Remove(categoryToDelete);
                    ctx.SaveChanges();
                }
            }
        }

        public void UpdateProduct(Product productToUpdate)
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                var dbProduct = productToUpdate.ToDbProduct();

                var dbFreshProduct = ctx.Products
                       .Single(c => c.ProductId == dbProduct.ProductId);

                ctx.Entry(dbFreshProduct).CurrentValues.SetValues(dbProduct);

                ctx.SaveChanges();
            }
        }
    }
}
