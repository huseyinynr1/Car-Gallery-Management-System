using Application.Features.MaintenanceTypes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.MaintenanceTypes.Rules;

public class MaintenanceTypeBusinessRules : BaseBusinessRules
{
    private readonly IMaintenanceTypeRepository _maintenanceTypeRepository;
    private readonly ILocalizationService _localizationService;

    public MaintenanceTypeBusinessRules(IMaintenanceTypeRepository maintenanceTypeRepository, ILocalizationService localizationService)
    {
        _maintenanceTypeRepository = maintenanceTypeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MaintenanceTypesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MaintenanceTypeShouldExistWhenSelected(MaintenanceType? maintenanceType)
    {
        if (maintenanceType == null)
            await throwBusinessException(MaintenanceTypesBusinessMessages.MaintenanceTypeNotExists);
    }

    public async Task MaintenanceTypeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        MaintenanceType? maintenanceType = await _maintenanceTypeRepository.GetAsync(
            predicate: mt => mt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MaintenanceTypeShouldExistWhenSelected(maintenanceType);
    }
}