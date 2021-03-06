﻿using System.Linq;
using System.Data.Entity;
using KMC.Northwind.Demo.SQL.Repository.POCO;

namespace KMC.Northwind.Demo.Tests.Common.Helpers
{
    public static class CategoryHelper
    {
        public static void DeleteCategoryById(int categoryId)
        {
            using (var ctx = new NorthwindDbContext())
            {
                var categoryToDelete = ctx.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
                if(categoryToDelete != null)
                {
                    foreach (var dbProduct in categoryToDelete.Products.ToArray())
                        ctx.Entry<Product>(dbProduct).State = EntityState.Modified;

                    ctx.Categories.Remove(categoryToDelete);
                    ctx.SaveChanges();
                }
            }
        }

        public static Category FindRecordByName(string name)
        {
            using (var ctx = new NorthwindDbContext())
            {
                return ctx.Categories
                       .Include(x => x.Products)
                       .Single(c => c.CategoryName == name);
            }
        }

        public static Category FindRecordId(int categoryId)
        {
            using (var ctx = new NorthwindDbContext())
            {
                return ctx.Categories
                    .Where(c => c.CategoryId == categoryId)
                    .FirstOrDefault();
            }
        }
    }
}
