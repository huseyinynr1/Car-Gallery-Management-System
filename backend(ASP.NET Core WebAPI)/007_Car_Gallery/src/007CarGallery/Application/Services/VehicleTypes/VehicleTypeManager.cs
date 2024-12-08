using Application.Features.VehicleTypes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.VehicleTypes;

public class VehicleTypeManager : IVehicleTypeService
{
    private readonly IVehicleTypeRepository _vehicleTypeRepository;
    private readonly VehicleTypeBusinessRules _vehicleTypeBusinessRules;

    public VehicleTypeManager(IVehicleTypeRepository vehicleTypeRepository, VehicleTypeBusinessRules vehicleTypeBusinessRules)
    {
        _vehicleTypeRepository = vehicleTypeRepository;
        _vehicleTypeBusinessRules = vehicleTypeBusinessRules;
    }

    public async Task<VehicleType?> GetAsync(
        Expression<Func<VehicleType, bool>> predicate,
        Func<IQueryable<VehicleType>, IIncludableQueryable<VehicleType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        VehicleType? vehicleType = await _vehicleTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return vehicleType;
    }

    public async Task<IPaginate<VehicleType>?> GetListAsync(
        Expression<Func<VehicleType, bool>>? predicate = null,
        Func<IQueryable<VehicleType>, IOrderedQueryable<VehicleType>>? orderBy = null,
        Func<IQueryable<VehicleType>, IIncludableQueryable<VehicleType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<VehicleType> vehicleTypeList = await _vehicleTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return vehicleTypeList;
    }

    public async Task<VehicleType> AddAsync(VehicleType vehicleType)
    {
        VehicleType addedVehicleType = await _vehicleTypeRepository.AddAsync(vehicleType);

        return addedVehicleType;
    }

    public async Task<VehicleType> UpdateAsync(VehicleType vehicleType)
    {
        VehicleType updatedVehicleType = await _vehicleTypeRepository.UpdateAsync(vehicleType);

        return updatedVehicleType;
    }

    public async Task<VehicleType> DeleteAsync(VehicleType vehicleType, bool permanent = false)
    {
        VehicleType deletedVehicleType = await _vehicleTypeRepository.DeleteAsync(vehicleType);

        return deletedVehicleType;
    }
}
