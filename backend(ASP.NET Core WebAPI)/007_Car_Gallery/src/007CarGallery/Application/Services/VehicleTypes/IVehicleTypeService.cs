using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.VehicleTypes;

public interface IVehicleTypeService
{
    Task<VehicleType?> GetAsync(
        Expression<Func<VehicleType, bool>> predicate,
        Func<IQueryable<VehicleType>, IIncludableQueryable<VehicleType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<VehicleType>?> GetListAsync(
        Expression<Func<VehicleType, bool>>? predicate = null,
        Func<IQueryable<VehicleType>, IOrderedQueryable<VehicleType>>? orderBy = null,
        Func<IQueryable<VehicleType>, IIncludableQueryable<VehicleType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<VehicleType> AddAsync(VehicleType vehicleType);
    Task<VehicleType> UpdateAsync(VehicleType vehicleType);
    Task<VehicleType> DeleteAsync(VehicleType vehicleType, bool permanent = false);
}
