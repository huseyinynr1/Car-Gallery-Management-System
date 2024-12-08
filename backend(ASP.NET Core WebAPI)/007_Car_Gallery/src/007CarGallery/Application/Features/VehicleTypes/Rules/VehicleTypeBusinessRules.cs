using Application.Features.VehicleTypes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.VehicleTypes.Rules;

public class VehicleTypeBusinessRules : BaseBusinessRules
{
    private readonly IVehicleTypeRepository _vehicleTypeRepository;
    private readonly ILocalizationService _localizationService;

    public VehicleTypeBusinessRules(IVehicleTypeRepository vehicleTypeRepository, ILocalizationService localizationService)
    {
        _vehicleTypeRepository = vehicleTypeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, VehicleTypesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task VehicleTypeShouldExistWhenSelected(VehicleType? vehicleType)
    {
        if (vehicleType == null)
            await throwBusinessException(VehicleTypesBusinessMessages.VehicleTypeNotExists);
    }

    public async Task VehicleTypeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        VehicleType? vehicleType = await _vehicleTypeRepository.GetAsync(
            predicate: vt => vt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await VehicleTypeShouldExistWhenSelected(vehicleType);
    }
}