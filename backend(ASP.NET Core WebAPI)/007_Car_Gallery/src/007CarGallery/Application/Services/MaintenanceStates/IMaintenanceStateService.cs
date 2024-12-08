using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaintenanceStates;

public interface IMaintenanceStateService
{
    Task<MaintenanceState?> GetAsync(
        Expression<Func<MaintenanceState, bool>> predicate,
        Func<IQueryable<MaintenanceState>, IIncludableQueryable<MaintenanceState, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MaintenanceState>?> GetListAsync(
        Expression<Func<MaintenanceState, bool>>? predicate = null,
        Func<IQueryable<MaintenanceState>, IOrderedQueryable<MaintenanceState>>? orderBy = null,
        Func<IQueryable<MaintenanceState>, IIncludableQueryable<MaintenanceState, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MaintenanceState> AddAsync(MaintenanceState maintenanceState);
    Task<MaintenanceState> UpdateAsync(MaintenanceState maintenanceState);
    Task<MaintenanceState> DeleteAsync(MaintenanceState maintenanceState, bool permanent = false);
}
