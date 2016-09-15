using KMC.Northwind.Demo.Core.Model;

namespace KMC.Northwind.Demo.Core.Interface.BusinessLogic
{
    public interface ISupplierOperation
    {
        Supplier[] FindSuppliers(SearchCriteria criteria);
        Supplier FindSupplierById(int supplierId);
        void CreateSupplier(Supplier newSupplier);
        void UpdateSupplier(Supplier supplierToUpdate);
        void RemoveSupplier(Supplier supplierToRemove);
    }
}
