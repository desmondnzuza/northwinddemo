using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;

namespace KMC.Northwind.Demo.BusinessLogic
{
    public class SupplierOperation : ISupplierOperation
    {
        private readonly ISupplierRepository _repo;
        public SupplierOperation(ISupplierRepository repository)
        {
            _repo = repository;
        }

        public Supplier FindSupplierById(int supplierId)
        {
            return _repo.FindSupplierById(supplierId);
        }

        public Supplier[] FindSuppliers(SearchCriteria criteria)
        {
            return _repo.FindSuppliers(criteria);
        }

        public void UpdateSupplier(Supplier supplierToUpdate)
        {
            _repo.UpdateSupplier(supplierToUpdate);
        }

        public void RemoveSupplier(Supplier supplierToRemove)
        {
            _repo.RemoveSupplier(supplierToRemove);
        }

        public void CreateSupplier(Supplier newSupplier)
        {
            _repo.CreateSupplier(newSupplier);
        }
    }
}
