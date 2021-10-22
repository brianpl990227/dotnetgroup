using Catalog.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Infraestructure.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts(string shopId);
        Task<Product> GetProduct(string id);
        Task<IEnumerable<Product>> GetProductByName(string name, string shopId);
        Task<IEnumerable<Product>> GetProductByCategory(string categoryName, string shopId);
        Task<IEnumerable<string>> GetProductCategories(string shopId);
        Task CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string id);
    }
}
