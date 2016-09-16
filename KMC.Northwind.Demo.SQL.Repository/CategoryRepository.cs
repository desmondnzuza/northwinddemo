using KMC.Northwind.Demo.Core.Interface.Repository;
using KMC.Northwind.Demo.Core.Model;
using KMC.Northwind.Demo.SQL.Repository.Helpers;
using System.Collections.Generic;
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
                ctx.Categories.Add(newCategory.ToDbModelCategory());

                ctx.SaveChanges();
            }
        }

        public Category[] FindCategories(SearchCriteria criteria)
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                var dbResults = ctx.Categories
                    .Include(x => x.Products)
                    //.Take(10)
                    //.Skip(0)
                    .Where(c =>
                        (c.CategoryName.Contains(criteria.SearchTerm) ||
                            c.Description.Contains(criteria.SearchTerm
                            ) || criteria.SearchTerm == null)               //TODO: handle this better
                            )
                     .ToArray();

                return dbResults
                      .Select(x => x.ToCoreModelCategory())
                      .ToArray();

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
                    return dbCategory.ToCoreModelCategory();
                }
            }

            return null;
        }

        public void RemoveCategory(Category categoryToRemove)
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                var categoryToDelete = ctx.Categories
                    .Include(x => x.Products)
                    .FirstOrDefault(c => c.CategoryId == categoryToRemove.Id);

                if (categoryToDelete != null)
                {
                    foreach (var dbProduct in categoryToDelete.Products.ToArray())
                        ctx.Entry<SQLPOCO.Product>(dbProduct).State = EntityState.Modified;

                    ctx.Categories.Remove(categoryToDelete);
                    ctx.SaveChanges();
                }
            }
        }

        public void UpdateCategory(Category categoryToUpdate)
        {
            using (var ctx = new SQLPOCO.NorthwindDbContext())
            {
                var dbNewCategory = categoryToUpdate.ToDbModelCategory();

                var dbFreshCategory = ctx.Categories
                       .Include(x => x.Products)
                       .Single(c => c.CategoryId == dbNewCategory.CategoryId);

                ctx.Entry(dbFreshCategory).CurrentValues.SetValues(dbNewCategory);

                foreach (var dbProduct in dbFreshCategory.Products.ToArray())
                    if (!dbNewCategory.Products.Any(s => s.ProductId == dbProduct.ProductId))
                        ctx.Products.Remove(dbProduct);

                foreach (var newProduct in dbNewCategory.Products)
                {
                    var dbProduct = dbFreshCategory.Products.SingleOrDefault(s => s.ProductId == newProduct.ProductId);
                    if (dbProduct != null)
                        ctx.Entry(dbProduct).CurrentValues.SetValues(newProduct);
                    else
                        dbFreshCategory.Products.Add(newProduct);
                }

                ctx.SaveChanges();
            }
        }
    }
}
