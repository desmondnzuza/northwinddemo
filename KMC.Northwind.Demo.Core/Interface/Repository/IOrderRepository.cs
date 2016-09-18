using KMC.Northwind.Demo.Core.Model;

namespace KMC.Northwind.Demo.Core.Interface.Repository
{
    public interface IOrderRepository
    {
        Order[] FindOrdersBeingShiped();
    }
}
