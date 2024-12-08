using Application.Features.CarStatusHistories.Constants;
using Application.Features.CarStatusHistories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CarStatusHistories.Constants.CarStatusHistoriesOperationClaims;

namespace Application.Features.CarStatusHistories.Commands.Create;

public class CreateCarStatusHistoryCommand : IRequest<CreatedCarStatusHistoryResponse>, ISecuredRequest
{
    public int CarId { get; set; }
    public int CarStatusId { get; set; }
    public DateTime StatusChange { get; set; }
    public string Remark { get; set; }

    public string[] Roles => [Admin, Write, CarStatusHistoriesOperationClaims.Create];

    public class CreateCarStatusHistoryCommandHandler : IRequestHandler<CreateCarStatusHistoryCommand, CreatedCarStatusHistoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarStatusHistoryRepository _carStatusHistoryRepository;
        private readonly CarStatusHistoryBusinessRules _carStatusHistoryBusinessRules;

        public CreateCarStatusHistoryCommandHandler(IMapper mapper, ICarStatusHistoryRepository carStatusHistoryRepository,
                                         CarStatusHistoryBusinessRules carStatusHistoryBusinessRules)
        {
            _mapper = mapper;
            _carStatusHistoryRepository = carStatusHistoryRepository;
            _carStatusHistoryBusinessRules = carStatusHistoryBusinessRules;
        }

        public async Task<CreatedCarStatusHistoryResponse> Handle(CreateCarStatusHistoryCommand request, CancellationToken cancellationToken)
        {
            CarStatusHistory carStatusHistory = _mapper.Map<CarStatusHistory>(request);

            await _carStatusHistoryRepository.AddAsync(carStatusHistory);

            CreatedCarStatusHistoryResponse response = _mapper.Map<CreatedCarStatusHistoryResponse>(carStatusHistory);
            return response;
        }
    }
}