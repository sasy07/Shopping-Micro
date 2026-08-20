using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class ProductSeedData
{
    public static void SeedData(IMongoCollection<Product> collection)
    {
        var existCollection = collection.Find(x => true).Any();
        if (existCollection) return;
        var pathJson = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "products.json");
        if (!File.Exists(pathJson))
        {
            throw new Exception($"Products seed data file not found: {pathJson}");
        }
        var dataText = File.ReadAllText(pathJson);
        var products = JsonSerializer.Deserialize<List<Product>>(dataText);
        if (products != null) collection.InsertMany(products);
    }
}