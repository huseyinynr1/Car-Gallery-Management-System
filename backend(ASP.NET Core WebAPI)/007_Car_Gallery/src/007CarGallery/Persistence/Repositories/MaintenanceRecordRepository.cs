using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories;

public class MaintenanceRecordRepository : EfRepositoryBase<MaintenanceRecord, int, BaseDbContext>, IMaintenanceRecordRepository
{
    public MaintenanceRecordRepository(BaseDbContext context) : base(context)
    {
    }
  

    public async Task<int> GetCountAsync(Expression<Func<MaintenanceRecord, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        int count = await Context.Set<MaintenanceRecord>().CountAsync(predicate, cancellationToken);
        return count;
    }

    public async Task<int> GetDistinctCountAsync(Expression<Func<MaintenanceRecord, bool>>? predicate = null, Expression<Func<MaintenanceRecord, int>>? distinctProperty = null, CancellationToken cancellationToken = default)
    {
        int count = await Context.Set<MaintenanceRecord>().Where(predicate).Select(distinctProperty).Distinct().CountAsync(cancellationToken);
        return count;
    }

    public async Task<int> GetTotalCostAsync(Expression<Func<MaintenanceRecord, bool>> predicate = null, CancellationToken cancellationToken = default)
    {
        int totalCost = await Context.Set<MaintenanceRecord>().Where(predicate).SumAsync(mr => mr.DealPrice ?? 0 , cancellationToken);
        return totalCost;
    }
}