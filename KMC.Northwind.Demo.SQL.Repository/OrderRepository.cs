using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;
using SQLPOCO = KMC.Northwind.Demo.SQL.Repository.POCO;
using System.Linq;
using KMC.Northwind.Demo.SQL.Repository.Helpers;

namespace KMC.Northwind.Demo.SQL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Order[] FindOrdersBeingShiped()
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                var dbResults = ctx.Orders
                    .Where(o => o.ShippedDate.HasValue)
                    .ToArray();

                return dbResults
                      .Select(x => x.ToCoreModeOrder())
                      .ToArray();
            }
        }
    }
}
