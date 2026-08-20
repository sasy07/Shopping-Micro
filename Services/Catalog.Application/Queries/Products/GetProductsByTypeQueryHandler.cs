using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Queries.Products
{
    public class GetProductsByTypeQuery(string type): IRequest<List<ProductResponse>>
    {
        public string Type { get; set; } = type;
    }
    public class GetProductsByTypeQueryHandler(IProductRepository productRepository , IMapper mapper): IRequestHandler<GetProductsByTypeQuery, List<ProductResponse>>
    {
        public async Task<List<ProductResponse>> Handle(GetProductsByTypeQuery request, CancellationToken cancellationToken)
        {
            var result = await productRepository.GetProductsByType(request.Type);
            return mapper.Map<List<ProductResponse>>(result);
        }
    }
}
