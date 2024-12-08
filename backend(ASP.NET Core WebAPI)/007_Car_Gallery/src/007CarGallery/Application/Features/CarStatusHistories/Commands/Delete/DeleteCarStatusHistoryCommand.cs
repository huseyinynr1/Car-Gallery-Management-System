using Application.Features.CarStatusHistories.Constants;
using Application.Features.CarStatusHistories.Constants;
using Application.Features.CarStatusHistories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CarStatusHistories.Constants.CarStatusHistoriesOperationClaims;

namespace Application.Features.CarStatusHistories.Commands.Delete;

public class DeleteCarStatusHistoryCommand : IRequest<DeletedCarStatusHistoryResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, CarStatusHistoriesOperationClaims.Delete];

    public class DeleteCarStatusHistoryCommandHandler : IRequestHandler<DeleteCarStatusHistoryCommand, DeletedCarStatusHistoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarStatusHistoryRepository _carStatusHistoryRepository;
        private readonly CarStatusHistoryBusinessRules _carStatusHistoryBusinessRules;

        public DeleteCarStatusHistoryCommandHandler(IMapper mapper, ICarStatusHistoryRepository carStatusHistoryRepository,
                                         CarStatusHistoryBusinessRules carStatusHistoryBusinessRules)
        {
            _mapper = mapper;
            _carStatusHistoryRepository = carStatusHistoryRepository;
            _carStatusHistoryBusinessRules = carStatusHistoryBusinessRules;
        }

        public async Task<DeletedCarStatusHistoryResponse> Handle(DeleteCarStatusHistoryCommand request, CancellationToken cancellationToken)
        {
            CarStatusHistory? carStatusHistory = await _carStatusHistoryRepository.GetAsync(predicate: csh => csh.Id == request.Id, cancellationToken: cancellationToken);
            await _carStatusHistoryBusinessRules.CarStatusHistoryShouldExistWhenSelected(carStatusHistory);

            await _carStatusHistoryRepository.DeleteAsync(carStatusHistory!);

            DeletedCarStatusHistoryResponse response = _mapper.Map<DeletedCarStatusHistoryResponse>(carStatusHistory);
            return response;
        }
    }
}