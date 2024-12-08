using Application.Features.CarStatusHistories.Constants;
using Application.Features.CarStatusHistories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CarStatusHistories.Constants.CarStatusHistoriesOperationClaims;

namespace Application.Features.CarStatusHistories.Queries.GetById;

public class GetByIdCarStatusHistoryQuery : IRequest<GetByIdCarStatusHistoryResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdCarStatusHistoryQueryHandler : IRequestHandler<GetByIdCarStatusHistoryQuery, GetByIdCarStatusHistoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarStatusHistoryRepository _carStatusHistoryRepository;
        private readonly CarStatusHistoryBusinessRules _carStatusHistoryBusinessRules;

        public GetByIdCarStatusHistoryQueryHandler(IMapper mapper, ICarStatusHistoryRepository carStatusHistoryRepository, CarStatusHistoryBusinessRules carStatusHistoryBusinessRules)
        {
            _mapper = mapper;
            _carStatusHistoryRepository = carStatusHistoryRepository;
            _carStatusHistoryBusinessRules = carStatusHistoryBusinessRules;
        }

        public async Task<GetByIdCarStatusHistoryResponse> Handle(GetByIdCarStatusHistoryQuery request, CancellationToken cancellationToken)
        {
            CarStatusHistory? carStatusHistory = await _carStatusHistoryRepository.GetAsync(predicate: csh => csh.Id == request.Id, cancellationToken: cancellationToken);
            await _carStatusHistoryBusinessRules.CarStatusHistoryShouldExistWhenSelected(carStatusHistory);

            GetByIdCarStatusHistoryResponse response = _mapper.Map<GetByIdCarStatusHistoryResponse>(carStatusHistory);
            return response;
        }
    }
}