using KMC.Northwind.Demo.BusinessLogic;
using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.SQL.Repository;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace KMC.Northwind.Demo.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ISupplierRepository, SupplierRepository>();

            container.RegisterType<ICategoryOperation, CategoryOperation>();
            container.RegisterType<IProductOperation, ProductOperation>();
            container.RegisterType<ISupplierOperation, SupplierOperation>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}