using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreModel = KMC.Northwind.Demo.Core.Model;
using SQLPOCO = KMC.Northwind.Demo.SQL.Repository.POCO;

namespace KMC.Northwind.Demo.SQL.Repository.Helpers
{
    internal static class ModelExtenstion
    {
        internal static SQLPOCO.Category ToDatabaseCategory(this CoreModel.Category category)
        {
            return new POCO.Category
            {
                CategoryId = category.Id,
                CategoryName = category.Name,
                Description = category.Description,
                Picture = category.Picture
            };
        }

        internal static CoreModel.Category ToModelCategory(this SQLPOCO.Category category)
        {
            return new CoreModel.Category
            {
                Id = category.CategoryId,
                Name = category.CategoryName,
                Description = category.Description,
                Picture = category.Picture
            };
        }
    }
}
