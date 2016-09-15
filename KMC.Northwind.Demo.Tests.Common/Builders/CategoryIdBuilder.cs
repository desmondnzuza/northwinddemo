using KMC.Northwind.Demo.SQL.Repository.POCO;

namespace KMC.Northwind.Demo.Tests.Common.Builders
{
    public class CategoryIdBuilder
    {
        private string _name;
        private string _description;

        public CategoryIdBuilder WithName(string name)
        {
            _name = name;

            return this;
        }

        public CategoryIdBuilder WithDescription(string description)
        {
            _description = description;

            return this;
        }

        public int Build()
        {
            using (var ctx = new NorthwindDbContext())
            {
                var itemToAdd = new Category
                {
                    CategoryName = _name,
                    Description = _description
                };

                ctx.Categories.Add(itemToAdd);

                ctx.SaveChanges();

                return itemToAdd.CategoryId;
            }
        }
    }
}
