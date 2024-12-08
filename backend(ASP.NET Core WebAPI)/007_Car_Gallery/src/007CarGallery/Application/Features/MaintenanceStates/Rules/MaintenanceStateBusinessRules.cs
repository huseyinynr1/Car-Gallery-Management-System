using Application.Features.MaintenanceStates.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.MaintenanceStates.Rules;

public class MaintenanceStateBusinessRules : BaseBusinessRules
{
    private readonly IMaintenanceStateRepository _maintenanceStateRepository;
    private readonly ILocalizationService _localizationService;

    public MaintenanceStateBusinessRules(IMaintenanceStateRepository maintenanceStateRepository, ILocalizationService localizationService)
    {
        _maintenanceStateRepository = maintenanceStateRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MaintenanceStatesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MaintenanceStateShouldExistWhenSelected(MaintenanceState? maintenanceState)
    {
        if (maintenanceState == null)
            await throwBusinessException(MaintenanceStatesBusinessMessages.MaintenanceStateNotExists);
    }

    public async Task MaintenanceStateIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        MaintenanceState? maintenanceState = await _maintenanceStateRepository.GetAsync(
            predicate: ms => ms.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MaintenanceStateShouldExistWhenSelected(maintenanceState);
    }
}