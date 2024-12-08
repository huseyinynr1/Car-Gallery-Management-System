using Application.Features.CarStatusHistories.Constants;
using Application.Features.CarStatusHistories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CarStatusHistories.Constants.CarStatusHistoriesOperationClaims;

namespace Application.Features.CarStatusHistories.Commands.Update;

public class UpdateCarStatusHistoryCommand : IRequest<UpdatedCarStatusHistoryResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int CarStatusId { get; set; }
    public DateTime StatusChange { get; set; }
    public string Remark { get; set; }

    public string[] Roles => [Admin, Write, CarStatusHistoriesOperationClaims.Update];

    public class UpdateCarStatusHistoryCommandHandler : IRequestHandler<UpdateCarStatusHistoryCommand, UpdatedCarStatusHistoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarStatusHistoryRepository _carStatusHistoryRepository;
        private readonly CarStatusHistoryBusinessRules _carStatusHistoryBusinessRules;

        public UpdateCarStatusHistoryCommandHandler(IMapper mapper, ICarStatusHistoryRepository carStatusHistoryRepository,
                                         CarStatusHistoryBusinessRules carStatusHistoryBusinessRules)
        {
            _mapper = mapper;
            _carStatusHistoryRepository = carStatusHistoryRepository;
            _carStatusHistoryBusinessRules = carStatusHistoryBusinessRules;
        }

        public async Task<UpdatedCarStatusHistoryResponse> Handle(UpdateCarStatusHistoryCommand request, CancellationToken cancellationToken)
        {
            CarStatusHistory? carStatusHistory = await _carStatusHistoryRepository.GetAsync(predicate: csh => csh.Id == request.Id, cancellationToken: cancellationToken);
            await _carStatusHistoryBusinessRules.CarStatusHistoryShouldExistWhenSelected(carStatusHistory);
            carStatusHistory = _mapper.Map(request, carStatusHistory);

            await _carStatusHistoryRepository.UpdateAsync(carStatusHistory!);

            UpdatedCarStatusHistoryResponse response = _mapper.Map<UpdatedCarStatusHistoryResponse>(carStatusHistory);
            return response;
        }
    }
}