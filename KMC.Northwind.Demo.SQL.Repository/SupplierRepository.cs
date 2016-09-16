using KMC.Northwind.Demo.Core.Interface.Repository;
using System;
using System.Linq;
using KMC.Northwind.Demo.Core.Model;
using KMC.Northwind.Demo.SQL.Repository.Helpers;
using SQLPOCO = KMC.Northwind.Demo.SQL.Repository.POCO;
using System.Data.Entity;

namespace KMC.Northwind.Demo.SQL.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        public void CreateSupplier(Supplier newSupplier)
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                ctx.Suppliers.Add(newSupplier.ToDbSupplier());

                ctx.SaveChanges();
            }
        }

        public Supplier[] FindAll()
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                var dbResults = ctx.Suppliers
                     .Include(x => x.Products)
                     .ToArray();

                var targetList = dbResults                    
                      .Select(x => x.ToCoreModelSupplier())
                      .ToArray();

                return targetList;
            }
        }

        public Supplier FindSupplierById(int supplierId)
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                var dbSupplier = ctx.Suppliers
                    .FirstOrDefault(c => c.SupplierId == supplierId);

                if (dbSupplier != null)
                {
                    return dbSupplier.ToCoreModelSupplier();
                }
            }

            return null;
        }

        public Supplier[] FindSuppliers(SearchCriteria criteria)
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                var dbResults = ctx.Suppliers
                    .Include(x => x.Products)
                    //.Take(10)
                    //.Skip(0)
                    .Where(c =>
                          (c.CompanyName.Contains(criteria.SearchTerm) ||
                            c.ContactName.Contains(criteria.SearchTerm) ||
                            criteria.SearchTerm == null))                       //TODO: handle this better
                     .ToArray();

                return dbResults
                      .Select(x => x.ToCoreModelSupplier())
                      .ToArray();
            }
        }

        public void RemoveSupplier(Supplier supplierToRemove)
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                var supplierToDelete = ctx.Suppliers
                    .Include(x => x.Products)
                    .FirstOrDefault(c => c.SupplierId == supplierToRemove.Id);

                if (supplierToDelete != null)
                {
                    foreach (var dbProduct in supplierToDelete.Products.ToArray())
                        ctx.Entry<SQLPOCO.Product>(dbProduct).State = EntityState.Modified;

                    ctx.Suppliers.Remove(supplierToDelete);
                    ctx.SaveChanges();
                }
            }
        }

        public void UpdateSupplier(Supplier supplierToUpdate)
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                var dbNewSupplier = supplierToUpdate.ToDbSupplier();

                var dbFreshSupplier = ctx.Suppliers
                       .Include(x => x.Products)
                       .Single(c => c.SupplierId == dbNewSupplier.SupplierId);

                ctx.Entry(dbFreshSupplier).CurrentValues.SetValues(dbNewSupplier);

                foreach (var dbProduct in dbFreshSupplier.Products.ToArray())
                    if (!dbNewSupplier.Products.Any(s => s.ProductId == dbProduct.ProductId))
                        ctx.Products.Remove(dbProduct);

                foreach (var newProduct in dbNewSupplier.Products)
                {
                    var dbProduct = dbFreshSupplier.Products.SingleOrDefault(s => s.ProductId == newProduct.ProductId);
                    if (dbProduct != null)
                        ctx.Entry(dbProduct).CurrentValues.SetValues(newProduct);
                    else
                        dbFreshSupplier.Products.Add(newProduct);
                }

                ctx.SaveChanges();
            }
        }
    }
}
