using KMC.Northwind.Demo.Core.Model;

namespace KMC.Northwind.Demo.Core.Interface.Repository
{
    public interface ISupplierRepository
    {
        Supplier[] FindSuppliers(SearchCriteria criteria);
        Supplier[] FindAll();
        Supplier FindSupplierById(int supplierId);
        void CreateSupplier(Supplier newSupplier);
        void UpdateSupplier(Supplier supplierToUpdate);
        void RemoveSupplier(Supplier supplierToRemove);
    }
}
