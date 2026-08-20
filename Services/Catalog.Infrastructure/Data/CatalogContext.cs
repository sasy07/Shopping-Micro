using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public class CatalogContext : ICatalogContext
{
    public CatalogContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSetting:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSetting:DatabaseName"));
        //Get the collection names from the configuration and create the collections
        Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSetting:CollectionName"));
        Brands = database.GetCollection<ProductBrand>(configuration.GetValue<string>("DatabaseSetting:BrandsCollection"));
        Types = database.GetCollection<ProductType>(configuration.GetValue<string>("DatabaseSetting:TypesCollection"));
        // Seed the data
        BrandSeedData.SeedData(Brands);
        TypeSeedData.SeedData(Types);
        ProductSeedData.SeedData(Products);
    }
    public IMongoCollection<Product> Products { get; }
    public IMongoCollection<ProductBrand> Brands { get; }
    public IMongoCollection<ProductType> Types { get; }
}