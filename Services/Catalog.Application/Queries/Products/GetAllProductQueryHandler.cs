using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Queries.Products
{
    public class GetAllProductQuery : IRequest<IEnumerable<ProductResponse>> { }

    public class GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        : IRequestHandler<GetAllProductQuery, IEnumerable<ProductResponse>>
    {
        public async Task<IEnumerable<ProductResponse>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var result = await productRepository.GetProducts();
            return mapper.Map<IEnumerable<ProductResponse>>(result);
        }
    }
}
