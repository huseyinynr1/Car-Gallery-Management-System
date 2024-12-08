using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using System.Linq.Expressions;

namespace Application.Services.Repositories;

public interface IMaintenanceRecordRepository : IAsyncRepository<MaintenanceRecord, int>, IRepository<MaintenanceRecord, int>
{
    Task<int> GetCountAsync(Expression<Func<MaintenanceRecord, bool>>? predicate = null,  CancellationToken cancellationToken = default);
    Task<int> GetDistinctCountAsync(Expression<Func<MaintenanceRecord, bool>>? predicate = null, Expression<Func<MaintenanceRecord, int>>? distinctProperty = null, CancellationToken cancellationToken = default);

    Task<int> GetTotalCostAsync(Expression<Func<MaintenanceRecord, bool>>? predicate = null, CancellationToken cancellationToken = default);

}