using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;
using SQLPOCO = KMC.Northwind.Demo.SQL.Repository.POCO;
using System.Linq;

namespace KMC.Northwind.Demo.SQL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Order[] FindOrdersBeingShiped()
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                var dbResults = ctx.Orders
                     .ToArray();

                return dbResults
                      .Select(x => new Order())
                      .ToArray();
            }
        }
    }
}
