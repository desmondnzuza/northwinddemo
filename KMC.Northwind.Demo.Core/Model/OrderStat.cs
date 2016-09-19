namespace KMC.Northwind.Demo.Core.Model
{
    public class OrderStat
    {
        public string Title { get; set; }
        public int Total { get; set; }
        public OrderStat[] OrderStats { get; set; }
    }
}
