using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;
using System.Collections.Generic;

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
            var results = new List<OrderStat>();
            var orders = _repo.FindOrdersBeingShiped();

            //TODO: group results by location
            //each location makes up a stat item
            //include totals
            foreach (var order in orders)
            {
                results.Add(new OrderStat());
            }

            return results.ToArray();
        }
    }
}
