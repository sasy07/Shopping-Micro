using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Commands.Products
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
        public ProductBrand Brands { get; set; }
        public ProductType Types { get; set; }
    }
    internal class UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<UpdateProductCommand, bool>
    {
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Product>(request);
            return await productRepository.UpdateProduct(product);
        }
    }
}
