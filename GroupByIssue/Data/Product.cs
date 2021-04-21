using System.Collections.Generic;

namespace GroupByIssue.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }

    public static class Products
    {
        public static readonly IList<Product> All = new List<Product>
        {
            new Product { Id = 1, Category = "Test Category", Name = "Test Name" }
        };
    }
}