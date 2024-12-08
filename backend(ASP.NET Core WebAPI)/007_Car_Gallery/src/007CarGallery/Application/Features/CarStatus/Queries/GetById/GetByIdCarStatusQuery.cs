using Application.Features.CarStatus.Constants;
using Application.Features.CarStatus.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CarStatus.Constants.CarStatusOperationClaims;

namespace Application.Features.CarStatus.Queries.GetById;

public class GetByIdCarStatusQuery : IRequest<GetByIdCarStatusResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdCarStatusQueryHandler : IRequestHandler<GetByIdCarStatusQuery, GetByIdCarStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarStatusRepository _carStatusRepository;
        private readonly CarStatusBusinessRules _carStatusBusinessRules;

        public GetByIdCarStatusQueryHandler(IMapper mapper, ICarStatusRepository carStatusRepository, CarStatusBusinessRules carStatusBusinessRules)
        {
            _mapper = mapper;
            _carStatusRepository = carStatusRepository;
            _carStatusBusinessRules = carStatusBusinessRules;
        }

        public async Task<GetByIdCarStatusResponse> Handle(GetByIdCarStatusQuery request, CancellationToken cancellationToken)
        {
            CarStatusEntity? carStatus = await _carStatusRepository.GetAsync(predicate: cs => cs.Id == request.Id, cancellationToken: cancellationToken);
            await _carStatusBusinessRules.CarStatusShouldExistWhenSelected(carStatus);

            GetByIdCarStatusResponse response = _mapper.Map<GetByIdCarStatusResponse>(carStatus);
            return response;
        }
    }
}