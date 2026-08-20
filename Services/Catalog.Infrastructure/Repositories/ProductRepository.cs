using System;
using System.Collections.Generic;
using System.Text;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository(ICatalogContext context): IProductRepository
    {
        public async Task<IEnumerable<Product>> GetProducts()
            => await context.Products.Find(x=>true).ToListAsync();

        public async Task<Product> GetProductById(string id)
            => await context.Products.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
            => await context.Products.Find(x => x.Name == name).ToListAsync();

        public async Task<IEnumerable<Product>> GetProductsByTypeId(string typeId)
            => await context.Products.Find(x => x.Types.Id == typeId).ToListAsync();

        public async Task<IEnumerable<Product>> GetProductsByType(string type)
            => await context.Products.Find(x => x.Types.Name == type).ToListAsync();

        public async Task<IEnumerable<Product>> GetProductsByBrandId(string brandId)
            => await context.Products.Find(x => x.Brands.Id == brandId).ToListAsync();

        public async Task<IEnumerable<Product>> GetProductsByBrand(string brand)
            => await context.Products.Find(x => x.Brands.Name == brand).ToListAsync();

        public async Task<Product> CreateProduct(Product product)
        {
            await context.Products.InsertOneAsync(product);
            return product;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var result = await context.Products.ReplaceOneAsync(x => x.Id == product.Id, product);
            return result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var result = await context.Products.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            var result = await context.Products.DeleteOneAsync(x => x.Id == product.Id);
            return result.DeletedCount > 0;
        }
    }
}
