using Application.Features.MaintenancePlanningRecords.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Cars.Constants;

namespace Application.Features.MaintenancePlanningRecords.Rules;

public class MaintenancePlanningRecordBusinessRules : BaseBusinessRules
{
    private readonly IMaintenancePlanningRecordRepository _maintenancePlanningRecordRepository;
    private readonly ILocalizationService _localizationService;

    public MaintenancePlanningRecordBusinessRules(IMaintenancePlanningRecordRepository maintenancePlanningRecordRepository, ILocalizationService localizationService)
    {
        _maintenancePlanningRecordRepository = maintenancePlanningRecordRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MaintenancePlanningRecordsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MaintenancePlanningRecordShouldExistWhenSelected(MaintenancePlanningRecord? maintenancePlanningRecord)
    {
        if (maintenancePlanningRecord == null)
            await throwBusinessException(MaintenancePlanningRecordsBusinessMessages.MaintenancePlanningRecordNotExists);
    }

    public async Task MaintenancePlanningRecordIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        MaintenancePlanningRecord? maintenancePlanningRecord = await _maintenancePlanningRecordRepository.GetAsync(
            predicate: mpr => mpr.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MaintenancePlanningRecordShouldExistWhenSelected(maintenancePlanningRecord);
    }

    public async Task CarShouldExistWhenSelected(Car? car)
    {
        if (car == null)
            await throwBusinessException(MaintenancePlanningRecordsBusinessMessages.CarNotExists);
    }

    public async Task BrandShouldExistWhenSelected(Brand? brand)
    {
        if (brand == null)
            await throwBusinessException(MaintenancePlanningRecordsBusinessMessages.BrandNotExists);
    }

    public async Task ModelShouldExistWhenSelected(Model? model)
    {
        if (model == null)
            await throwBusinessException(MaintenancePlanningRecordsBusinessMessages.ModelNotExists);
    }

    public async Task MaintenanceStatesShouldExistWhenSelected(MaintenanceState? maintenanceState)
    {
        if (maintenanceState == null)
            await throwBusinessException(MaintenancePlanningRecordsBusinessMessages.MaintenanceStateNotExists);
    }

    public async Task MaintenanceTypeShouldExistWhenSelected(MaintenanceType? maintenanceType)
    {
        if (maintenanceType == null)
            await throwBusinessException(MaintenancePlanningRecordsBusinessMessages.MaintenanceTypeNotExists);
    }

    
}