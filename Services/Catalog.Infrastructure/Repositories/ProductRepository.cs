using System;
using System.Collections.Generic;
using System.Text;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository: IProductRepository
    {
        public async Task<IEnumerable<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductsByTypeId(string typeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductsByType(string type)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductsByBrandId(string brandId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductsByBrand(string brand)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteProduct(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
