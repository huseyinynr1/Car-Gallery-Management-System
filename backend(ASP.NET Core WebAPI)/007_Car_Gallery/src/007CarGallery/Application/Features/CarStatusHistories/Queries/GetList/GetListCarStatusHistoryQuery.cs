using Application.Features.CarStatusHistories.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.CarStatusHistories.Constants.CarStatusHistoriesOperationClaims;

namespace Application.Features.CarStatusHistories.Queries.GetList;

public class GetListCarStatusHistoryQuery : IRequest<GetListResponse<GetListCarStatusHistoryListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListCarStatusHistoryQueryHandler : IRequestHandler<GetListCarStatusHistoryQuery, GetListResponse<GetListCarStatusHistoryListItemDto>>
    {
        private readonly ICarStatusHistoryRepository _carStatusHistoryRepository;
        private readonly IMapper _mapper;

        public GetListCarStatusHistoryQueryHandler(ICarStatusHistoryRepository carStatusHistoryRepository, IMapper mapper)
        {
            _carStatusHistoryRepository = carStatusHistoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCarStatusHistoryListItemDto>> Handle(GetListCarStatusHistoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CarStatusHistory> carStatusHistories = await _carStatusHistoryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCarStatusHistoryListItemDto> response = _mapper.Map<GetListResponse<GetListCarStatusHistoryListItemDto>>(carStatusHistories);
            return response;
        }
    }
}