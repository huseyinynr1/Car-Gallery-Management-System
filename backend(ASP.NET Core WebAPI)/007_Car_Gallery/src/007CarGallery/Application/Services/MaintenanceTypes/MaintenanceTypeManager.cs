using Application.Features.MaintenanceTypes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaintenanceTypes;

public class MaintenanceTypeManager : IMaintenanceTypeService
{
    private readonly IMaintenanceTypeRepository _maintenanceTypeRepository;
    private readonly MaintenanceTypeBusinessRules _maintenanceTypeBusinessRules;

    public MaintenanceTypeManager(IMaintenanceTypeRepository maintenanceTypeRepository, MaintenanceTypeBusinessRules maintenanceTypeBusinessRules)
    {
        _maintenanceTypeRepository = maintenanceTypeRepository;
        _maintenanceTypeBusinessRules = maintenanceTypeBusinessRules;
    }

    public async Task<MaintenanceType?> GetAsync(
        Expression<Func<MaintenanceType, bool>> predicate,
        Func<IQueryable<MaintenanceType>, IIncludableQueryable<MaintenanceType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MaintenanceType? maintenanceType = await _maintenanceTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return maintenanceType;
    }

    public async Task<IPaginate<MaintenanceType>?> GetListAsync(
        Expression<Func<MaintenanceType, bool>>? predicate = null,
        Func<IQueryable<MaintenanceType>, IOrderedQueryable<MaintenanceType>>? orderBy = null,
        Func<IQueryable<MaintenanceType>, IIncludableQueryable<MaintenanceType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MaintenanceType> maintenanceTypeList = await _maintenanceTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return maintenanceTypeList;
    }

    public async Task<MaintenanceType> AddAsync(MaintenanceType maintenanceType)
    {
        MaintenanceType addedMaintenanceType = await _maintenanceTypeRepository.AddAsync(maintenanceType);

        return addedMaintenanceType;
    }

    public async Task<MaintenanceType> UpdateAsync(MaintenanceType maintenanceType)
    {
        MaintenanceType updatedMaintenanceType = await _maintenanceTypeRepository.UpdateAsync(maintenanceType);

        return updatedMaintenanceType;
    }

    public async Task<MaintenanceType> DeleteAsync(MaintenanceType maintenanceType, bool permanent = false)
    {
        MaintenanceType deletedMaintenanceType = await _maintenanceTypeRepository.DeleteAsync(maintenanceType);

        return deletedMaintenanceType;
    }
}
