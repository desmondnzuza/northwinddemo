using KMC.Northwind.Demo.Core.Interface.Repository;
using System;
using System.Linq;
using KMC.Northwind.Demo.Core.Model;
using SQLPOCO = KMC.Northwind.Demo.SQL.Repository.POCO;
using System.Data.Entity;

namespace KMC.Northwind.Demo.SQL.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        public void CreateSupplier(Supplier newSupplier)
        {
            throw new NotImplementedException();
        }

        public Supplier FindSupplierById(int supplierId)
        {
            throw new NotImplementedException();
        }

        public Supplier[] FindSuppliers(SearchCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public void RemoveSupplier(Supplier supplierToRemove)
        {
            throw new NotImplementedException();
        }

        public void UpdateSupplier(Supplier supplierToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
