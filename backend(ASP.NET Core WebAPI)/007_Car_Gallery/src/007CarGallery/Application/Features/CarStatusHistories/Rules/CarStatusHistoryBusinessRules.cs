using Application.Features.CarStatusHistories.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.CarStatusHistories.Rules;

public class CarStatusHistoryBusinessRules : BaseBusinessRules
{
    private readonly ICarStatusHistoryRepository _carStatusHistoryRepository;
    private readonly ILocalizationService _localizationService;

    public CarStatusHistoryBusinessRules(ICarStatusHistoryRepository carStatusHistoryRepository, ILocalizationService localizationService)
    {
        _carStatusHistoryRepository = carStatusHistoryRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CarStatusHistoriesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CarStatusHistoryShouldExistWhenSelected(CarStatusHistory? carStatusHistory)
    {
        if (carStatusHistory == null)
            await throwBusinessException(CarStatusHistoriesBusinessMessages.CarStatusHistoryNotExists);
    }

    public async Task CarStatusHistoryIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CarStatusHistory? carStatusHistory = await _carStatusHistoryRepository.GetAsync(
            predicate: csh => csh.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CarStatusHistoryShouldExistWhenSelected(carStatusHistory);
    }
}