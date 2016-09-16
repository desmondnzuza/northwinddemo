using System.Linq;
using System.Data.Entity;
using KMC.Northwind.Demo.SQL.Repository.POCO;
using DbModel = KMC.Northwind.Demo.SQL.Repository.POCO;
using CoreModel = KMC.Northwind.Demo.Core.Model;
using KMC.Northwind.Demo.SQL.Repository.Helpers;
using System;

namespace KMC.Northwind.Demo.Tests.Common.Helpers
{
    public static class ProductHelper
    {
        public static CoreModel.Product[] FindTopProducts(int top)
        {
            using (var ctx = new DbModel.NorthwindDbContext())
            {
                var dbResults = ctx.Products
                       .Take(top)
                       .ToArray();

                return dbResults
                      .Select(x => x.ToCoreModelProduct())
                      .ToArray();
            }
        }

        public static void DeleteProductById(int _productId)
        {
            using (var ctx = new NorthwindDbContext())
            {
                var productToDelete = ctx.Products.FirstOrDefault(c => c.ProductId == _productId);

                if (productToDelete != null)
                {
                    ctx.Products.Remove(productToDelete);
                    ctx.SaveChanges();
                }
            }
        }

        public static Product FindRecordByName(string name)
        {
            using (var ctx = new NorthwindDbContext())
            {
                return ctx.Products
                       .FirstOrDefault(c => c.ProductName == name);
            }
        }

        public static object FindProductById(int _productId)
        {
            using (var ctx = new NorthwindDbContext())
            {
                return ctx.Products
                       .FirstOrDefault(c => c.ProductId == _productId);
            }
        }
    }
}
