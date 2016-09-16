using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMC.Northwind.Demo.SQL.Repository.POCO;

namespace KMC.Northwind.Demo.Tests.Common.Helpers
{
    public class SupplierHelper
    {
        public static void DeleteSupplierById(int _supplierId)
        {
            using (var ctx = new NorthwindDbContext())
            {
                var supplierToDelete = ctx.Suppliers.FirstOrDefault(c => c.SupplierId == _supplierId);

                if (supplierToDelete != null)
                {
                    ctx.Suppliers.Remove(supplierToDelete);
                    ctx.SaveChanges();
                }
            }
        }

        public static Supplier FindSupplierByCompanyName(string name)
        {
            using (var ctx = new NorthwindDbContext())
            {
                return ctx.Suppliers.FirstOrDefault(s => s.CompanyName == name);
            }
        }

        public static Supplier FindSupplierById(int _supplierId)
        {
            using (var ctx = new NorthwindDbContext())
            {
                return ctx.Suppliers.FirstOrDefault(s => s.SupplierId == _supplierId);
            }
        }
    }
}
