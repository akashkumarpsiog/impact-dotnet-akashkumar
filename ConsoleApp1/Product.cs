using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog
{
    public enum Category
    {
        OnSale,
        OutOfStock,
        Available
    }
    public class Product
    {
        private string _name;
        private decimal _price;
        private Category _category;
        public Category ProductCategory { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price, Category category)
        {
            Name = name;
            Price = price;
            ProductCategory = category;
        }

    }
}
