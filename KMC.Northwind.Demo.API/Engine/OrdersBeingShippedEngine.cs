﻿using KMC.Northwind.Demo.API.Hubs;
using KMC.Northwind.Demo.BusinessLogic;
using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
using KMC.Northwind.Demo.Core.Model;
using KMC.Northwind.Demo.SQL.Repository;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KMC.Northwind.Demo.API.Engine
{
    public class OrdersBeingShippedEngine
    {
        private IOrderOperation _operation;
        private IHubContext _hubs;
        private readonly int _pollIntervalInMilliseconds;

        public OrdersBeingShippedEngine(int pollIntervalInMilliseconds)
        {
            //_operation = DependencyResolver.Current.GetService<IOrderOperation>();
            var repo = new OrderRepository();
            _operation = new OrderOperation(repo);
            _hubs = GlobalHost.ConnectionManager.GetHubContext<OrdersBeingShippedHub>();
            _pollIntervalInMilliseconds = pollIntervalInMilliseconds;
        }

        public async Task OnStatsMonitor()
        {
            //Monitor for infinity!
            while (true)
            {
                await Task.Delay(_pollIntervalInMilliseconds);

                IEnumerable<OrderStat> statItems = _operation.FindOrdersBeingShiped();
                _hubs.Clients.All.broadcastOrderStats(statItems);
                _hubs.Clients.All.serverTime(DateTime.UtcNow.ToString());
            }
        }

        public void Stop(bool immediate)
        {

        }

    }
}