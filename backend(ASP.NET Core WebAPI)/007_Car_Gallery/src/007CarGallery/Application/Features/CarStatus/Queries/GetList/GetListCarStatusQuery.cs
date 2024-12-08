using Application.Features.CarStatus.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.CarStatus.Constants.CarStatusOperationClaims;

namespace Application.Features.CarStatus.Queries.GetList;

public class GetListCarStatusQuery : IRequest<GetListResponse<GetListCarStatusListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListCarStatusQueryHandler : IRequestHandler<GetListCarStatusQuery, GetListResponse<GetListCarStatusListItemDto>>
    {
        private readonly ICarStatusRepository _carStatusRepository;
        private readonly IMapper _mapper;

        public GetListCarStatusQueryHandler(ICarStatusRepository carStatusRepository, IMapper mapper)
        {
            _carStatusRepository = carStatusRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCarStatusListItemDto>> Handle(GetListCarStatusQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CarStatusEntity> carStatus = await _carStatusRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCarStatusListItemDto> response = _mapper.Map<GetListResponse<GetListCarStatusListItemDto>>(carStatus);
            return response;
        }
    }
}