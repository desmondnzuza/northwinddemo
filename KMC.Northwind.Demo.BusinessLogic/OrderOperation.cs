using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace KMC.Northwind.Demo.BusinessLogic
{
    public class OrderOperation : IOrderOperation
    {
        private readonly IOrderRepository _repo;
        public OrderOperation(IOrderRepository repository)
        {
            _repo = repository;
        }

        public OrderStat[] FindOrdersBeingShiped()
        {
            var results = new OrderStat[] { };
            var orders = _repo.FindOrdersBeingShiped();

            return orders
                .OrderBy(x => x.ShipCountry)
                .GroupBy(x => x.ShipCountry)
                .Select(g => new OrderStat
                {
                    Title = g.Key,
                    Total = g.Count(),
                    OrderStats = g
                    .OrderBy(x => x.ShipPostalCode)
                    .GroupBy(x => x.ShipPostalCode)
                    .Select(x => new OrderStat
                    {
                        Title = x.Key,                        
                        Total = x.Count()
                    }).ToArray()
                }).ToArray();
        }
    }
}
