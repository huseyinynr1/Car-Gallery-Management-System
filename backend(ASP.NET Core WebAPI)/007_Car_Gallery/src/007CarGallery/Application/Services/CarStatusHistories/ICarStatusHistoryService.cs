using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CarStatusHistories;

public interface ICarStatusHistoryService
{
    Task<CarStatusHistory?> GetAsync(
        Expression<Func<CarStatusHistory, bool>> predicate,
        Func<IQueryable<CarStatusHistory>, IIncludableQueryable<CarStatusHistory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CarStatusHistory>?> GetListAsync(
        Expression<Func<CarStatusHistory, bool>>? predicate = null,
        Func<IQueryable<CarStatusHistory>, IOrderedQueryable<CarStatusHistory>>? orderBy = null,
        Func<IQueryable<CarStatusHistory>, IIncludableQueryable<CarStatusHistory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CarStatusHistory> AddAsync(CarStatusHistory carStatusHistory);
    Task<CarStatusHistory> UpdateAsync(CarStatusHistory carStatusHistory);
    Task<CarStatusHistory> DeleteAsync(CarStatusHistory carStatusHistory, bool permanent = false);
}
