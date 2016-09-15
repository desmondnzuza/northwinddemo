using System.Linq;
using KMC.Northwind.Demo.SQL.Repository.POCO;

namespace KMC.Northwind.Demo.Tests.Common.Helpers
{
    public static class CategoryHelper
    {
        public static void DeleteCategoryById(int categoryId)
        {
            using (var ctx = new NorthwindDbContext())
            {
                var categoryToDelete = ctx.Categories.First(c => c.CategoryId == categoryId);
                if(categoryToDelete != null)
                {
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
                    .Where(c => c.CategoryName == name)
                    .FirstOrDefault();
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
