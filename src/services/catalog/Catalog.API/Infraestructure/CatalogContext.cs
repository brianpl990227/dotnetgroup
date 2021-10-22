using Catalog.API.Entities;
using Catalog.API.Entities.Configurations;
using Catalog.API.Infraestructure.Exceptions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace Catalog.API.Infraestructure
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IOptions<DatabaseSettingsOptions> options)
        {
            _ = options ?? throw new ArgumentNullException(nameof(options));
            DatabaseSettingsOptions optionsValue = options.Value ?? throw new CatalogException(nameof(options.Value));

            var client = new MongoClient(optionsValue.ConnectionString);
            var database = client.GetDatabase(optionsValue.DatabaseName);

            Products = database.GetCollection<Product>(optionsValue.CollectionName);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
