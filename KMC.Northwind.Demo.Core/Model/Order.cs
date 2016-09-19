using System;

namespace KMC.Northwind.Demo.Core.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string ShipCountry { get; set; }
        public string ShiptCity { get; set; }
        public string ShipPostalCode { get; set; }
    }
}
