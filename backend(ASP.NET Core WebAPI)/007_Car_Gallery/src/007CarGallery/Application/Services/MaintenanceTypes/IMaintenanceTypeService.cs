using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaintenanceTypes;

public interface IMaintenanceTypeService
{
    Task<MaintenanceType?> GetAsync(
        Expression<Func<MaintenanceType, bool>> predicate,
        Func<IQueryable<MaintenanceType>, IIncludableQueryable<MaintenanceType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MaintenanceType>?> GetListAsync(
        Expression<Func<MaintenanceType, bool>>? predicate = null,
        Func<IQueryable<MaintenanceType>, IOrderedQueryable<MaintenanceType>>? orderBy = null,
        Func<IQueryable<MaintenanceType>, IIncludableQueryable<MaintenanceType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MaintenanceType> AddAsync(MaintenanceType maintenanceType);
    Task<MaintenanceType> UpdateAsync(MaintenanceType maintenanceType);
    Task<MaintenanceType> DeleteAsync(MaintenanceType maintenanceType, bool permanent = false);
}
