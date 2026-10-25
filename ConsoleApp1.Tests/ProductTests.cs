using System;
using System.Collections.Generic;
using System.Text;
using ProductCatalog;
using Xunit;

namespace ConsoleApp1.Tests
{
    public class ProductTests
    {
        [Fact]
        public void GroupByCategory_GroupProductsCorrectly()
        {
            // Arrange - prepare test data
            var products = new List<Product>
        {
            new("Laptop", 75000m, Category.Available),
            new("Mouse", 1200m, Category.OnSale),
            new("Keyboard", 2500m, Category.Available),
            new("Monitor", 12000m, Category.OutOfStock),
            new("Phone", 30000m, Category.OnSale)
        };

            // Act - call the real application logic
            var groups = ProductCatalogService
                .GroupByCategory(products)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Assert: verify the expected results
            Assert.Equal(3, groups.Count);

            Assert.Equal(new[] { "Keyboard", "Laptop"},
                groups[Category.Available]
                .Select(p => p.Name)
                .OrderBy(name => name)
                .ToArray());

            Assert.Equal(
                new[] { "Mouse", "Phone" },
                groups[Category.OnSale]
                    .Select(p => p.Name)
                    .OrderBy(name => name)
                    .ToArray());

            Assert.Equal(
                new[] { "Monitor" },
                groups[Category.OutOfStock]
                    .Select(p => p.Name)
                    .ToArray());

        }

        [Fact]
        public void GroupByCategory_PreservesEveryProductExactlyOnce()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product("Laptop", 75000m, Category.Available),
                new Product("Mouse", 1200m, Category.OnSale),
                new Product("Keyboard", 2500m, Category.Available)
            };

            // Act
            var groupedProducts = ProductCatalogService
                .GroupByCategory(products)
                .SelectMany(group => group)
                .ToList();

            // Assert
            Assert.Equal(products.Count, groupedProducts.Count);

            Assert.All(products, product =>
            {
                Assert.Equal(
                    1,
                    groupedProducts.Count(p => ReferenceEquals(p, product)));
            });
        }

        [Fact]
        public void GroupByCategory_ReturnsNoGroupsForEmptyInput()
        {
            // Arrange
            var products = new List<Product>();

            // Act
            var groups = ProductCatalogService
                .GroupByCategory(products)
                .ToList();

            // Assert
            Assert.Empty(groups);
        }

        [Fact]
        public void GroupByCategory_HandlesSingleProduct()
        {
            // Arrange
            var product = new Product(
                "Laptop", 75000m, Category.Available);

            // Act
            var groups = ProductCatalogService
                .GroupByCategory(new[] { product })
                .ToList();

            // Assert
            var group = Assert.Single(groups);

            Assert.Equal(Category.Available, group.Key);
            Assert.Same(product, Assert.Single(group));
        }

        [Fact]
        public void GroupByCategory_DoesNotModifyOriginalCollection()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product("Laptop", 75000m, Category.Available),
                new Product("Mouse", 1200m, Category.OnSale)
            };

            var originalOrder = products.ToArray();

            // Act
            _ = ProductCatalogService.GroupByCategory(products).ToList();

            // Assert
            Assert.Equal(2, products.Count);

            for (int i = 0; i < products.Count; i++)
            {
                Assert.Same(originalOrder[i], products[i]);
            }
        }

        [Fact]
        public void GroupByCategory_ThrowsWhenInputIsNull()
        {
            // Arrange
            IEnumerable<Product> products = null!;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(
                () => ProductCatalogService.GroupByCategory(products));
        }



    }
}
