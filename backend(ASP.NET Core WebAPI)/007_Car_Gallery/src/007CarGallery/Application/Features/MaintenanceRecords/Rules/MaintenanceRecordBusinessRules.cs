using Application.Features.MaintenanceRecords.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.MaintenancePlanningRecords.Constants;

namespace Application.Features.MaintenanceRecords.Rules;

public class MaintenanceRecordBusinessRules : BaseBusinessRules
{
    private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;
    private readonly ILocalizationService _localizationService;

    public MaintenanceRecordBusinessRules(IMaintenanceRecordRepository maintenanceRecordRepository, ILocalizationService localizationService)
    {
        _maintenanceRecordRepository = maintenanceRecordRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MaintenanceRecordsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MaintenanceRecordShouldExistWhenSelected(MaintenanceRecord? maintenanceRecord)
    {
        if (maintenanceRecord == null)
            await throwBusinessException(MaintenanceRecordsBusinessMessages.MaintenanceRecordNotExists);
    }

    public async Task MaintenanceRecordIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        MaintenanceRecord? maintenanceRecord = await _maintenanceRecordRepository.GetAsync(
            predicate: mr => mr.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MaintenanceRecordShouldExistWhenSelected(maintenanceRecord);
    }

    public async Task CarShouldExistWhenSelected(Car? car)
    {
        if (car == null)
            await throwBusinessException(MaintenanceRecordsBusinessMessages.CarNotExists);
    }

    public async Task BrandShouldExistWhenSelected(Brand? brand)
    {
        if (brand == null)
            await throwBusinessException(MaintenanceRecordsBusinessMessages.BrandNotExists);
    }

    public async Task ModelShouldExistWhenSelected(Model? model)
    {
        if (model == null)
            await throwBusinessException(MaintenanceRecordsBusinessMessages.ModelNotExists);
    }

    public async Task MaintenanceStatesShouldExistWhenSelected(MaintenanceState? maintenanceState)
    {
        if (maintenanceState == null)
            await throwBusinessException(MaintenanceRecordsBusinessMessages.MaintenanceStateNotExists);
    }

    public async Task MaintenanceTypeShouldExistWhenSelected(MaintenanceType? maintenanceType)
    {
        if (maintenanceType == null)
            await throwBusinessException(MaintenanceRecordsBusinessMessages.MaintenanceTypeNotExists);
    }

    public async Task MaintenanceRecordCountShouldExistWhenSelected(int maintenanceCount)
    {
        
        if(maintenanceCount == 0)
            await throwBusinessException(MaintenanceRecordsBusinessMessages.MaintenanceCountNotExists);
    }

}