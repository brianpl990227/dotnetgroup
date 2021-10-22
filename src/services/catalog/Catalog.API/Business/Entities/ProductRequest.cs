using System.Collections.Generic;

namespace Catalog.API.Business.Entities
{
    public class ProductRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShopId { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<string> Images { get; set; }
        public int AvailableStock { get; set; }
        public int MinumumStock { get; set; }
    }
}
