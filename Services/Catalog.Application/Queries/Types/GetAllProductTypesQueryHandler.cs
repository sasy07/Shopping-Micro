using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Queries.Types;

public class GetAllProductTypesQuery:IRequest<IEnumerable<TypeResponse>>{}

public class GetAllProductTypesQueryHandler (ITypeRepository typeRepository , IMapper mapper)
    : IRequestHandler<GetAllProductTypesQuery  , IEnumerable<TypeResponse>>
{
    public async Task<IEnumerable<TypeResponse>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
    {
        var result = await typeRepository.GetProductTypes();
        return mapper.Map<IEnumerable<TypeResponse>>(result);
    }
}