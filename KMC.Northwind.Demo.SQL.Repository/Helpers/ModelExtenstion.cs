using CoreModel = KMC.Northwind.Demo.Core.Model;
using DbModel = KMC.Northwind.Demo.SQL.Repository.POCO;
using System.Linq;

namespace KMC.Northwind.Demo.SQL.Repository.Helpers
{
    public static class ModelExtenstion
    {
        public static DbModel.Category ToDbModelCategory(this CoreModel.Category category)
        {
            return new DbModel.Category
            {
                CategoryId = category.Id,
                CategoryName = category.Name,
                Description = category.Description,
                Picture = category.Picture,

                Products = (category.Products != null && category.Products.Any()) ? 
                                        category.Products.Select(x => x.ToDbProduct()).ToArray() : 
                                        new DbModel.Product[] { }
            };
        }

        public static CoreModel.Category ToCoreModelCategory(this DbModel.Category category)
        {
            return new CoreModel.Category
            {
                Id = category.CategoryId,
                Name = category.CategoryName,
                Description = category.Description,
                Picture = category.Picture,

                Products = (category.Products != null && category.Products.Any()) ?
                                        category.Products.Select(x => x.ToCoreModelProduct()).ToArray() :
                                        new CoreModel.Product[] { }
            };
        }

        public static CoreModel.Product ToCoreModelProduct(this DbModel.Product product)
        {
            return new CoreModel.Product
            {
                Id = product.ProductId,
                Name = product.ProductName,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                ReorderLevel = product.ReorderLevel,
                IsDiscontinued = product.Discontinued,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId,
            };
        }

        public static DbModel.Product ToDbProduct(this CoreModel.Product product)
        {
            return new DbModel.Product
            {
                ProductId = product.Id,
                ProductName = product.Name,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                ReorderLevel = product.ReorderLevel,
                Discontinued = product.IsDiscontinued,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId,
            };
        }

        public static CoreModel.Supplier ToCoreModelSupplier(this DbModel.Supplier supplier)
        {
            return new CoreModel.Supplier
            {
                Id = supplier.SupplierId,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                City = supplier.City,
                Region = supplier.Region,
                PostalCode = supplier.PostalCode,
                Country = supplier.Country,
                Phone = supplier.Phone,
                Fax = supplier.Fax,
                HomePage = supplier.HomePage,
                
                Products = (supplier.Products != null && supplier.Products.Any()) ? supplier.Products.Select(x => x.ToCoreModelProduct()).ToArray() :
                                        new CoreModel.Product[] { }
            };
        }

        public static DbModel.Supplier ToDbSupplier(this CoreModel.Supplier supplier)
        {
            return new DbModel.Supplier
            {
                SupplierId = supplier.Id,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                City = supplier.City,
                Region = supplier.Region,
                PostalCode = supplier.PostalCode,
                Country = supplier.Country,
                Phone = supplier.Phone,
                Fax = supplier.Fax,
                HomePage = supplier.HomePage,
                
                Products = (supplier.Products != null && supplier.Products.Any()) ?
                                        supplier.Products.Select(x => x.ToDbProduct()).ToArray() :
                                        new DbModel.Product[] { }
            };
        }

        public static CoreModel.Order ToCoreModeOrder(this DbModel.Order order)
        {
            return new CoreModel.Order
            {
                Id = order.OrderId,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                ShipCountry = order.ShipCountry,
                ShipPostalCode = order.ShipPostalCode,
                ShiptCity = order.ShipCity
            };
        }
    }
}
