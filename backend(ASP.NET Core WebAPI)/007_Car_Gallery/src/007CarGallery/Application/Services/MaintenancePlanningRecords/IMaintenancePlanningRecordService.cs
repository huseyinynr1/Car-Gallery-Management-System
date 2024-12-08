using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaintenancePlanningRecords;

public interface IMaintenancePlanningRecordService
{
    Task<MaintenancePlanningRecord?> GetAsync(
        Expression<Func<MaintenancePlanningRecord, bool>> predicate,
        Func<IQueryable<MaintenancePlanningRecord>, IIncludableQueryable<MaintenancePlanningRecord, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MaintenancePlanningRecord>?> GetListAsync(
        Expression<Func<MaintenancePlanningRecord, bool>>? predicate = null,
        Func<IQueryable<MaintenancePlanningRecord>, IOrderedQueryable<MaintenancePlanningRecord>>? orderBy = null,
        Func<IQueryable<MaintenancePlanningRecord>, IIncludableQueryable<MaintenancePlanningRecord, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MaintenancePlanningRecord> AddAsync(MaintenancePlanningRecord maintenancePlanningRecord);
    Task<MaintenancePlanningRecord> UpdateAsync(MaintenancePlanningRecord maintenancePlanningRecord);
    Task<MaintenancePlanningRecord> DeleteAsync(MaintenancePlanningRecord maintenancePlanningRecord, bool permanent = false);
}
