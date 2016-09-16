using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
using KMC.Northwind.Demo.Core.Model;
using System.Web.Http;

namespace KMC.Northwind.Demo.API.Controllers
{
    public class SupplierController
    {
        private readonly ISupplierOperation _operation;

        public SupplierController(ISupplierOperation operation)
        {
            _operation = operation;
        }

        [HttpPost]
        public Supplier[] FindSuppliers([FromBody]SearchCriteria criteria)
        {
            return _operation.FindSuppliers(criteria);
        }

        [HttpGet]
        public Supplier FindSupplierById(int SupplierId)
        {
            return _operation.FindSupplierById(SupplierId);
        }

        [HttpPost]
        public void CreateSupplier(Supplier newSupplier)
        {
            _operation.CreateSupplier(newSupplier);
        }

        [HttpPost]
        public void UpdateSupplier(Supplier supplierToUpdate)
        {
            _operation.UpdateSupplier(supplierToUpdate);
        }

        [HttpPost]
        public void RemoveProduct(Supplier supplierToRemove)
        {
            _operation.RemoveSupplier(supplierToRemove);
        }
    }
}