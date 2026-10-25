using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog
{
    public static class ProductCatalogService
    {
        public static IEnumerable<IGrouping<Category, Product>> GroupByCategory(IEnumerable<Product> products)
        {
            ArgumentNullException.ThrowIfNull(products);
            return products.GroupBy(p => p.ProductCategory);
        }
    }
}
