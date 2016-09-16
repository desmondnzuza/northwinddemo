using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
using KMC.Northwind.Demo.Core.Model;
using System.Web.Http;

namespace KMC.Northwind.Demo.API.Controllers
{
    public class SupplierController : ApiController
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

        [HttpGet]
        public Product[] FindAvailableProducts()
        {
            return _operation.FindAvailableProducts();
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
        public void RemoveSupplier(Supplier supplierToRemove)
        {
            _operation.RemoveSupplier(supplierToRemove);
        }
    }
}