using Application.Features.CarStatusHistories.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CarStatusHistories;

public class CarStatusHistoryManager : ICarStatusHistoryService
{
    private readonly ICarStatusHistoryRepository _carStatusHistoryRepository;
    private readonly CarStatusHistoryBusinessRules _carStatusHistoryBusinessRules;

    public CarStatusHistoryManager(ICarStatusHistoryRepository carStatusHistoryRepository, CarStatusHistoryBusinessRules carStatusHistoryBusinessRules)
    {
        _carStatusHistoryRepository = carStatusHistoryRepository;
        _carStatusHistoryBusinessRules = carStatusHistoryBusinessRules;
    }

    public async Task<CarStatusHistory?> GetAsync(
        Expression<Func<CarStatusHistory, bool>> predicate,
        Func<IQueryable<CarStatusHistory>, IIncludableQueryable<CarStatusHistory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CarStatusHistory? carStatusHistory = await _carStatusHistoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return carStatusHistory;
    }

    public async Task<IPaginate<CarStatusHistory>?> GetListAsync(
        Expression<Func<CarStatusHistory, bool>>? predicate = null,
        Func<IQueryable<CarStatusHistory>, IOrderedQueryable<CarStatusHistory>>? orderBy = null,
        Func<IQueryable<CarStatusHistory>, IIncludableQueryable<CarStatusHistory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CarStatusHistory> carStatusHistoryList = await _carStatusHistoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return carStatusHistoryList;
    }

    public async Task<CarStatusHistory> AddAsync(CarStatusHistory carStatusHistory)
    {
        CarStatusHistory addedCarStatusHistory = await _carStatusHistoryRepository.AddAsync(carStatusHistory);

        return addedCarStatusHistory;
    }

    public async Task<CarStatusHistory> UpdateAsync(CarStatusHistory carStatusHistory)
    {
        CarStatusHistory updatedCarStatusHistory = await _carStatusHistoryRepository.UpdateAsync(carStatusHistory);

        return updatedCarStatusHistory;
    }

    public async Task<CarStatusHistory> DeleteAsync(CarStatusHistory carStatusHistory, bool permanent = false)
    {
        CarStatusHistory deletedCarStatusHistory = await _carStatusHistoryRepository.DeleteAsync(carStatusHistory);

        return deletedCarStatusHistory;
    }
}
