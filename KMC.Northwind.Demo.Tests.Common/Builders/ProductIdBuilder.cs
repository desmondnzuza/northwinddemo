using KMC.Northwind.Demo.SQL.Repository.POCO;

namespace KMC.Northwind.Demo.Tests.Common.Builders
{
    public class ProductIdBuilder
    {
        private string _name;

        public ProductIdBuilder WithName(string name)
        {
            _name = name;

            return this;
        }

        public int Build()
        {
            using (var ctx = new NorthwindDbContext())
            {
                var itemToAdd = new Product
                {
                    ProductName = _name,
                };

                ctx.Products.Add(itemToAdd);

                ctx.SaveChanges();

                return itemToAdd.ProductId;
            }
        }
    }
}
