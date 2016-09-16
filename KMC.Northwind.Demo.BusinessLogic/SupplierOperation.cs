using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;

namespace KMC.Northwind.Demo.BusinessLogic
{
    public class SupplierOperation : ISupplierOperation
    {
        private readonly ISupplierRepository _supplierRepo;
        private readonly IProductRepository _productRepo;

        public SupplierOperation(
            ISupplierRepository supplierRepository,
            IProductRepository productRepository)
        {
            _supplierRepo = supplierRepository;
            _productRepo = productRepository;
        }

        public Supplier FindSupplierById(int supplierId)
        {
            return _supplierRepo.FindSupplierById(supplierId);
        }

        public Supplier[] FindSuppliers(SearchCriteria criteria)
        {
            return _supplierRepo.FindSuppliers(criteria);
        }

        public void UpdateSupplier(Supplier supplierToUpdate)
        {
            _supplierRepo.UpdateSupplier(supplierToUpdate);
        }

        public void RemoveSupplier(Supplier supplierToRemove)
        {
            _supplierRepo.RemoveSupplier(supplierToRemove);
        }

        public void CreateSupplier(Supplier newSupplier)
        {
            _supplierRepo.CreateSupplier(newSupplier);
        }

        public Product[] FindAvailableProducts()
        {
            return _productRepo.FindAll();
        }
    }
}
