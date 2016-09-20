using KMC.Northwind.Demo.API.Configs;
using KMC.Northwind.Demo.API.Engine;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Newtonsoft.Json;
using Owin;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(KMC.Northwind.Demo.API.Startup))]

namespace KMC.Northwind.Demo.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new SignalRContractResolver();
            var serializer = JsonSerializer.Create(settings);
            GlobalHost.DependencyResolver.Register(typeof(JsonSerializer), () => serializer);

            var hubConfiguration = new HubConfiguration();
            hubConfiguration.EnableDetailedErrors = true;
            app.MapSignalR(hubConfiguration);

            OrdersBeingShippedEngine statsEngine = new OrdersBeingShippedEngine(800);
            Task.Factory.StartNew(async () => await statsEngine.OnStatsMonitor());
        }
    }
}
