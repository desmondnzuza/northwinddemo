using KMC.Northwind.Demo.SQL.Repository.POCO;

namespace KMC.Northwind.Demo.Tests.Common.Builders
{
    public class SupplierIdBuilder
    {
        private string _companyName;
        private string _contactName;

        public SupplierIdBuilder WithCompanyName(string name)
        {
            _companyName = name;

            return this;
        }

        public SupplierIdBuilder WithContactName(string name)
        {
            _contactName = name;

            return this;
        }

        public int Build()
        {
            using (var ctx = new NorthwindDbContext())
            {
                var itemToAdd = new Supplier
                {
                    CompanyName = _companyName,
                    ContactName = _contactName,
                };

                ctx.Suppliers.Add(itemToAdd);

                ctx.SaveChanges();

                return itemToAdd.SupplierId;
            }
        }
    }
}
