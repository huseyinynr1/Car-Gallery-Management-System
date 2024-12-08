using Application.Features.Cars.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Cars.Rules;

public class CarBusinessRules : BaseBusinessRules
{
    private readonly ICarRepository _carRepository;
    private readonly ILocalizationService _localizationService;

    public CarBusinessRules(ICarRepository carRepository, ILocalizationService localizationService)
    {
        _carRepository = carRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CarsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CarShouldExistWhenSelected(Car? car)
    {
        if (car == null)
            await throwBusinessException(CarsBusinessMessages.CarNotExists);
    }

    public async Task CarIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Car? car = await _carRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CarShouldExistWhenSelected(car);
    }

    public async Task BrandShouldExistWhenSelected(Brand? brand)
    {
        if (brand == null)
            await throwBusinessException(CarsBusinessMessages.BrandNotExists);
    }

    public async Task ModelShouldExistWhenSelected(Model? model)
    {
        if (model == null)
            await throwBusinessException(CarsBusinessMessages.ModelNotExists);
    }

    public async Task TransmissionShouldExistWhenSelected(Transmission? transmission)
    {
        if (transmission == null)
            await throwBusinessException(CarsBusinessMessages.TransmissionNotExists);
    }

    public async Task FuelShouldExistWhenSelected(Fuel? fuel)
    {
        if (fuel == null)
            await throwBusinessException(CarsBusinessMessages.FuelNotExists);
    }

    public async Task StatusShouldExistWhenSelected(CarStatusEntity? status)
    {
        if (status == null)
            await throwBusinessException(CarsBusinessMessages.StatusNotExists);
    }

    public async Task ChassisNoShouldBeProvided(string? chassisNo)
    {
        if (string.IsNullOrEmpty(chassisNo))
            await throwBusinessException(CarsBusinessMessages.ChassisNoIsRequired);
    }

}