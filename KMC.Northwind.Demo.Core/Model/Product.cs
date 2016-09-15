namespace KMC.Northwind.Demo.Core.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool IsDiscontinued { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
    }
}
