using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaintenanceRecords;

public interface IMaintenanceRecordService
{
    Task<MaintenanceRecord?> GetAsync(
        Expression<Func<MaintenanceRecord, bool>> predicate,
        Func<IQueryable<MaintenanceRecord>, IIncludableQueryable<MaintenanceRecord, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MaintenanceRecord>?> GetListAsync(
        Expression<Func<MaintenanceRecord, bool>>? predicate = null,
        Func<IQueryable<MaintenanceRecord>, IOrderedQueryable<MaintenanceRecord>>? orderBy = null,
        Func<IQueryable<MaintenanceRecord>, IIncludableQueryable<MaintenanceRecord, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MaintenanceRecord> AddAsync(MaintenanceRecord maintenanceRecord);
    Task<MaintenanceRecord> UpdateAsync(MaintenanceRecord maintenanceRecord);
    Task<MaintenanceRecord> DeleteAsync(MaintenanceRecord maintenanceRecord, bool permanent = false);
    
}
