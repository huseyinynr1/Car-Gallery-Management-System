using Application.Features.CarStatus.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.CarStatus.Rules;

public class CarStatusBusinessRules : BaseBusinessRules
{
    private readonly ICarStatusRepository _carStatusRepository;
    private readonly ILocalizationService _localizationService;

    public CarStatusBusinessRules(ICarStatusRepository carStatusRepository, ILocalizationService localizationService)
    {
        _carStatusRepository = carStatusRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CarStatusBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CarStatusShouldExistWhenSelected(CarStatusEntity? carStatus)
    {
        if (carStatus == null)
            await throwBusinessException(CarStatusBusinessMessages.CarStatusNotExists);
    }

    public async Task CarStatusIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CarStatusEntity? carStatus = await _carStatusRepository.GetAsync(
            predicate: cs => cs.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CarStatusShouldExistWhenSelected(carStatus);
    }
}