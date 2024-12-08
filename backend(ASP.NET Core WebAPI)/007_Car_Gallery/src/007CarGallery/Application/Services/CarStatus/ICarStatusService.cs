using NArchitecture.Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Domain.Entities;


namespace Application.Services.CarStatus;

public interface ICarStatusService
{
    Task<CarStatusEntity?> GetAsync(
        Expression<Func<CarStatusEntity, bool>> predicate,
        Func<IQueryable<CarStatusEntity>, IIncludableQueryable<CarStatusEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CarStatusEntity>?> GetListAsync(
        Expression<Func<CarStatusEntity, bool>>? predicate = null,
        Func<IQueryable<CarStatusEntity>, IOrderedQueryable<CarStatusEntity>>? orderBy = null,
        Func<IQueryable<CarStatusEntity>, IIncludableQueryable<CarStatusEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CarStatusEntity> AddAsync(CarStatusEntity carStatus);
    Task<CarStatusEntity> UpdateAsync(CarStatusEntity carStatus);
    Task<CarStatusEntity> DeleteAsync(CarStatusEntity carStatus, bool permanent = false);
}
