using Application.Features.CarStatus.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CarStatus;

public class CarStatusManager : ICarStatusService
{
    private readonly ICarStatusRepository _carStatusRepository;
    private readonly CarStatusBusinessRules _carStatusBusinessRules;

    public CarStatusManager(ICarStatusRepository carStatusRepository, CarStatusBusinessRules carStatusBusinessRules)
    {
        _carStatusRepository = carStatusRepository;
        _carStatusBusinessRules = carStatusBusinessRules;
    }

    public async Task<CarStatusEntity?> GetAsync(
        Expression<Func<CarStatusEntity, bool>> predicate,
        Func<IQueryable<CarStatusEntity>, IIncludableQueryable<CarStatusEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CarStatusEntity? carStatus = await _carStatusRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return carStatus;
    }

    public async Task<IPaginate<CarStatusEntity>?> GetListAsync(
        Expression<Func<CarStatusEntity, bool>>? predicate = null,
        Func<IQueryable<CarStatusEntity>, IOrderedQueryable<CarStatusEntity>>? orderBy = null,
        Func<IQueryable<CarStatusEntity>, IIncludableQueryable<CarStatusEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CarStatusEntity> carStatusList = await _carStatusRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return carStatusList;
    }

    public async Task<CarStatusEntity> AddAsync(CarStatusEntity carStatus)
    {
        CarStatusEntity addedCarStatus = await _carStatusRepository.AddAsync(carStatus);

        return addedCarStatus;
    }

    public async Task<CarStatusEntity> UpdateAsync(CarStatusEntity carStatus)
    {
        CarStatusEntity updatedCarStatus = await _carStatusRepository.UpdateAsync(carStatus);

        return updatedCarStatus;
    }

    public async Task<CarStatusEntity> DeleteAsync(CarStatusEntity carStatus, bool permanent = false)
    {
        CarStatusEntity deletedCarStatus = await _carStatusRepository.DeleteAsync(carStatus);

        return deletedCarStatus;
    }
}
