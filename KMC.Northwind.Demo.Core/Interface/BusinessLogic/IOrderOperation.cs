
using KMC.Northwind.Demo.Core.Model;

namespace KMC.Northwind.Demo.Core.Interface.BusinessLogic
{
    public interface IOrderOperation
    {
        OrderStat[] FindOrdersBeingShiped();
    }
}
