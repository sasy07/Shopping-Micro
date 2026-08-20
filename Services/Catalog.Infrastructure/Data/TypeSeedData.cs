using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class TypeSeedData
{
    public static void SeedData(IMongoCollection<ProductType> collection)
    {
        var existCollection = collection.Find(x => true).Any();
        if (existCollection) return;
        var pathJson = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "types.json");
        if (!File.Exists(pathJson))
        {
            throw new Exception($"Types seed data file not found: {pathJson}");
        }
        var dataText = File.ReadAllText(pathJson);
        var types = JsonSerializer.Deserialize<List<ProductType>>(dataText);
        if (types != null) collection.InsertMany(types);
    }
}