﻿namespace KMC.Northwind.Demo.Core.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public Product[] Products { get; set; }
    }
}
