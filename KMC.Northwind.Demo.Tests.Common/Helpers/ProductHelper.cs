using System.Linq;
using System.Data.Entity;
using DbModel = KMC.Northwind.Demo.SQL.Repository.POCO;
using CoreModel = KMC.Northwind.Demo.Core.Model;
using KMC.Northwind.Demo.SQL.Repository.Helpers;

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
    }
}
