using Application.Features.MaintenanceStates.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaintenanceStates;

public class MaintenanceStateManager : IMaintenanceStateService
{
    private readonly IMaintenanceStateRepository _maintenanceStateRepository;
    private readonly MaintenanceStateBusinessRules _maintenanceStateBusinessRules;

    public MaintenanceStateManager(IMaintenanceStateRepository maintenanceStateRepository, MaintenanceStateBusinessRules maintenanceStateBusinessRules)
    {
        _maintenanceStateRepository = maintenanceStateRepository;
        _maintenanceStateBusinessRules = maintenanceStateBusinessRules;
    }

    public async Task<MaintenanceState?> GetAsync(
        Expression<Func<MaintenanceState, bool>> predicate,
        Func<IQueryable<MaintenanceState>, IIncludableQueryable<MaintenanceState, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MaintenanceState? maintenanceState = await _maintenanceStateRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return maintenanceState;
    }

    public async Task<IPaginate<MaintenanceState>?> GetListAsync(
        Expression<Func<MaintenanceState, bool>>? predicate = null,
        Func<IQueryable<MaintenanceState>, IOrderedQueryable<MaintenanceState>>? orderBy = null,
        Func<IQueryable<MaintenanceState>, IIncludableQueryable<MaintenanceState, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MaintenanceState> maintenanceStateList = await _maintenanceStateRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return maintenanceStateList;
    }

    public async Task<MaintenanceState> AddAsync(MaintenanceState maintenanceState)
    {
        MaintenanceState addedMaintenanceState = await _maintenanceStateRepository.AddAsync(maintenanceState);

        return addedMaintenanceState;
    }

    public async Task<MaintenanceState> UpdateAsync(MaintenanceState maintenanceState)
    {
        MaintenanceState updatedMaintenanceState = await _maintenanceStateRepository.UpdateAsync(maintenanceState);

        return updatedMaintenanceState;
    }

    public async Task<MaintenanceState> DeleteAsync(MaintenanceState maintenanceState, bool permanent = false)
    {
        MaintenanceState deletedMaintenanceState = await _maintenanceStateRepository.DeleteAsync(maintenanceState);

        return deletedMaintenanceState;
    }
}
