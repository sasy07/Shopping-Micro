using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Queries.Products;

public class GetProductByIdQuery(string id) : IRequest<ProductResponse>
{
    public string Id { get; set; } = id;
}

public class GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<GetProductByIdQuery, ProductResponse>
{
    public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await productRepository.GetProductById(request.Id);
        return result == null 
            ? throw new Exception($"Product not found. Id :{request.Id}") 
            : mapper.Map<ProductResponse>(result);
    }
}