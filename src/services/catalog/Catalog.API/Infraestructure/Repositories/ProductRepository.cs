using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Infraestructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _catalogContext;
        public ProductRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
        }
        public async Task CreateProduct(Product product)
        {
            await _catalogContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _catalogContext
                .Products
                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _catalogContext.Products
                .Find(props => props.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName, string shopId)
        {
            FilterDefinition<Product> filterByCategoryName = Builders<Product>.Filter.Eq(p => p.Category, categoryName);
            FilterDefinition<Product> filterByShopId = Builders<Product>.Filter.Eq(p => p.ShopId, shopId);
            FilterDefinition<Product> filter = Builders<Product>.Filter.And(filterByCategoryName, filterByShopId);

            return await _catalogContext.Products
                .Find(filter)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetProductCategories(string shopId)
        {
            FilterDefinition<Product> filterByShopId = Builders<Product>.Filter.Eq(p => p.ShopId, shopId);
            var list = await _catalogContext.Products
                .Find(filterByShopId)
                .ToListAsync();
            return list.Select(x => x.Category).Distinct();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name, string shopId)
        {
            FilterDefinition<Product> filterByName = Builders<Product>.Filter.Eq(p => p.Name, name);
            FilterDefinition<Product> filterByShopId = Builders<Product>.Filter.Eq(p => p.ShopId, shopId);
            FilterDefinition<Product> filter = Builders<Product>.Filter.And(filterByName, filterByShopId);

            return await _catalogContext.Products
                .Find(filter)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts(string shopId)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.ShopId, shopId);

            return await _catalogContext.Products
                .Find(filter)
                .ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await _catalogContext.Products
                .ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
