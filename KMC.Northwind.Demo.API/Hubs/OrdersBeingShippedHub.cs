using KMC.Northwind.Demo.Core.Model;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KMC.Northwind.Demo.API.Hubs
{
    public class OrdersBeingShippedHub : Hub
    {
        public void SendStats(IEnumerable<OrderStat> categoryStatus)
        {
            Clients.All.broadcastOrderStats(categoryStatus);
        }

        public void Heartbeat()
        {
            Clients.All.heartbeat();
        }

        public override Task OnConnected()
        {
            return (base.OnConnected());
        }
    }
}