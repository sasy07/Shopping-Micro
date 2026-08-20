using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Commands.Products
{
    public class DeleteProductCommand(string id) : IRequest<bool>
    {
        public string Id { get; } = id;
    }
    public class DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<DeleteProductCommand, bool>
    {
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await productRepository.DeleteProduct(request.Id);
        }
    }
}
