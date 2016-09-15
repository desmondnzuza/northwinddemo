﻿using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;
using KMC.Northwind.Demo.SQL.Repository.Helpers;
using System.Data.Entity;
using System.Linq;
using SQLPOCO = KMC.Northwind.Demo.SQL.Repository.POCO;

namespace KMC.Northwind.Demo.SQL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public void CreateCategory(Category newCategory)
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                ctx.Categories.Add(newCategory.ToDatabaseCategory());

                ctx.SaveChanges();
            }
        }

        public Category[] FindCategories(SearchCriteria criteria)
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                var dbResults = ctx.Categories
                    //.Take(10)
                    //.Skip(0)
                    .Where(c =>
                        (c.CategoryName.Contains(criteria.SearchTerm) ||
                            c.Description.Contains(criteria.SearchTerm) /*||
                            string.IsNullOrWhiteSpace(criteria.SearchTerm)*/)
                            )
                     .ToArray();

                var targetList = dbResults
                      .Select(x => x.ToModelCategory())
                      .ToArray();

                return targetList;

            }
        }

        public Category FindCategoryById(int categoryId)
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                var dbCategory = ctx.Categories
                    .Where(c => c.CategoryId == categoryId)
                    .FirstOrDefault();

                if(dbCategory != null)
                {
                    return dbCategory.ToModelCategory();
                }
            }

            return null;
        }

        public void RemoveCategory(Category categoryToRemove)
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                var dbCategory = categoryToRemove.ToDatabaseCategory();

                ctx.Categories.Remove(dbCategory);

                ctx.SaveChanges();
            }
        }

        public void UpdateCategory(Category categoryToUpdate)
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                var dbCategory = categoryToUpdate.ToDatabaseCategory();

                ctx.Categories.Attach(dbCategory);
                ctx.Entry(dbCategory).State = EntityState.Modified;

                ctx.SaveChanges();
            }
        }
    }
}