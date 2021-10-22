using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Infraestructure
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
